using System.ComponentModel.DataAnnotations;

namespace LoremIpsumLogistica.Core.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }
                
        public virtual ICollection<Address> Addresses { get; set; }
    }
}