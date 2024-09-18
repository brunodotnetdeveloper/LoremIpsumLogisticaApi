using System.ComponentModel.DataAnnotations;

namespace LoremIpsumLogistica.Core.Entities
{
    public class Client: BaseEntity
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O sexo é obrigatório.")]
        [RegularExpression("^(Masculino|Feminino)$", ErrorMessage = "Sexo deve ser Masculino ou Feminino.")]
        public string Gender { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
