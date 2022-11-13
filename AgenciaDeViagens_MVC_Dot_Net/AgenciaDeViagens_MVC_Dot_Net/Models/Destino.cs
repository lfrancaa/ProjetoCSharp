using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagens_MVC_Dot_Net.Models
{
    [Table("Destino")]
    public class Destino

    {
        public int DestinoId { get; set; }
        [Display(Name = "IdDestino")]
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
