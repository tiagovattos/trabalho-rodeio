using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabalho_rodeio.Models
{
    [Table("Montarias")]
    public class Montaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public int PeaoId { get; set; } // ID do Peao associado à montaria

        [Required]
        public int TouroId { get; set; } // ID do Touro associado à montaria

        [ForeignKey("PeaoId")]
        public Peao Peao { get; set; }

        [ForeignKey("TouroId")]
        public Touro Touro { get; set; }
    }
}
