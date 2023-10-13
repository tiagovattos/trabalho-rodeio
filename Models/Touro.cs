using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabalho_rodeio.Models
{
    [Table("Touros")]
    public class Touro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public int Idade { get; set; }

        [Required]
        public int QuantidadeMontarias { get; set; }
    }
}
