using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TP02_MVC.Models
{
    public class Container
    {
        [Display(Name = "Código")]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        [Column("type")]
        public string Tipo { get; set; }

        [Display(Name = "Tamanho")]
        [Column("size")]
        public string Tamanho { get; set; }

        [Column("bl_id")]
        public int BlId { get; set; }

        [ForeignKey("BlId")]
        public Bl? Bl { get; set; }
    }
}
