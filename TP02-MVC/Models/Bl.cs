using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP02_MVC.Models
{
    [Table("bls")]
    public class Bl
    {
        [Display(Name = "Código")]
        [Column("id")]
        public int Id { get; set; } 

        [Display(Name = "Consignee")]
        [Column("consignee")]
        public string Consignee { get; set; } 

        [Display(Name = "Navio")]
        [Column("ship")]
        public int Ship { get; set; } 

        public virtual ICollection<Container>? Containers { get; set; }
    }
}
