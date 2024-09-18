using System.ComponentModel.DataAnnotations;

namespace LoremIpsumLogistica.Core.Entities
{
    public class Address: BaseEntity
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(9)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(150)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(10)]
        public string Numero { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(100)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(2)]
        public string Uf { get; set; }

        public virtual Client Client { get; set; }
    }
}
