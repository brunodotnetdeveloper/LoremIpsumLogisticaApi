using System.ComponentModel.DataAnnotations;

namespace LoremIpsumLogistica.Core.Entities
{
    public class Address: BaseEntity
    {
        [Required(ErrorMessage = "O tipo de endereço é obrigatório.")]
        public string Type { get; set; } // Comercial, Residencial

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter 8 caracteres.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        public string Number { get; set; }

        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string City { get; set; }

        [Required(ErrorMessage = "O estado (UF) é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve ter 2 caracteres.")]
        public string State { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
