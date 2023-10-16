using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Piadineria2.Dto;

namespace Piadineria2.Entities
{
    public class PiadinaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Prezzo { get; set; }

        [Required]
        [MaxLength(100)]
        public ICollection<IngredientEntity> Ingredients { get; set; } = new List<IngredientEntity>();

        [Required]
        [MaxLength(10)]
        public string Forma { get; set; }
    }
}
