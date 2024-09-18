using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoremIpsumLogistica.Infrastructure.Context
{
    public partial class LoremIpsumLogisticaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public LoremIpsumLogisticaDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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

                entity.Property(e => e.ZipCode)
                    .HasColumnName("zip_code") 
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.Street) 
                    .HasColumnName("street")   
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Number) 
                    .HasColumnName("number")   
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Complement)
                    .HasColumnName("complement")  
                    .HasMaxLength(50);

                entity.Property(e => e.Neighborhood) 
                    .HasColumnName("neighborhood")   
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .HasColumnName("city")  
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.State)
                    .HasColumnName("state")  
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Type)
                   .HasColumnName("type")
                   .IsRequired()
                   .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
