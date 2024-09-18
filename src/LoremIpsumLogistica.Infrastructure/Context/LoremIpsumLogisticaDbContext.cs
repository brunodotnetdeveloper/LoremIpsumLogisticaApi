using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoremIpsumLogistica.Infrastructure.Context
{
    /// <summary>
    /// Contexto de banco de dados para o Omni, contendo as definições das tabelas e configurações de conexão.
    /// </summary>
    public partial class LoremIpsumLogisticaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor que recebe uma instância de IConfiguration para acessar as configurações do banco de dados.
        /// </summary>
        public LoremIpsumLogisticaDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Construtor que recebe opções de DbContextOptions e uma instância de IConfiguration.
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public LoremIpsumLogisticaDbContext(DbContextOptions<LoremIpsumLogisticaDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Core.Entities.Client> Clients { get; set; }
        public virtual DbSet<Core.Entities.Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("LoremIpsumLogisticaConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Entities.Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .IsRequired();

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .IsRequired();

                entity.HasMany(e => e.Addresses)
                    .WithOne(a => a.Client)
                    .HasForeignKey(a => a.ClientId)
                    .OnDelete(DeleteBehavior.Cascade);  // Deletar endereços ao deletar cliente
            });

            modelBuilder.Entity<Core.Entities.Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(50);

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(100);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Uf)
                    .HasColumnName("uf")
                    .IsRequired()
                    .HasMaxLength(2);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
