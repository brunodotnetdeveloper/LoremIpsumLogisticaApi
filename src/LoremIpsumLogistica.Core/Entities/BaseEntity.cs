using System.ComponentModel.DataAnnotations;

namespace LoremIpsumLogistica.Core.Entities
{
    /// <summary>
    /// Classe base para todas as entidades de domínio, fornecendo uma propriedade de identificação única.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Identificador único para cada entidade de domínio.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Data de criação da empresa.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Data da última modificação da empresa.
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Indica se a empresa está ativa.
        /// </summary>
        public bool Active { get; set; } = true;
    }
}
