using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public List<string> Ingredienti { get; set; }

        [Required]
        [MaxLength(10)]
        public string Forma { get; set; }
    }
}
