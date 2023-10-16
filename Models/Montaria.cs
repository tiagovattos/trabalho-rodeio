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
        [Display(Name ="Data e Hora")]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name ="Peão")]
        public int PeaoId { get; set; }

        [Required]
        [Display(Name = "Touro")]
        public int TouroId { get; set; }

        [Required]
        [Display(Name ="Cidade")]
        public int CidadeId {  get; set; }

        [ForeignKey("PeaoId")]
        public Peao Peao { get; set; }

        [ForeignKey("TouroId")]
        public Touro Touro { get; set; }

        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }
    }
}
