using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piadineria2.Entities
{
    public class IngredientEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("PiadinaId")]
        public PiadinaEntity? Piadina { get; set; }
        public int PiadinaId { get; set; }
    }
}
