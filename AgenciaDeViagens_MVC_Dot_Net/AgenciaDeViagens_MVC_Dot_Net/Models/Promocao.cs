using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagens_MVC_Dot_Net.Models
{
    [Table("Promocao")]
    public class Promocao

    {
        public int PromocaoId { get; set; }
        [Display(Name = "IdPromocao")]
        [Required]
        [StringLength(100)]
        public string LocalViagem { get; set; }
        [Display(Name = "Local Viagem")]
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Display(Name = "Descricao")]
        [Required]
        [StringLength(100)]
        public string ValorViagem { get; set; }
    }
}
