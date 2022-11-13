using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagens_API.Models
{
    [Table("Hotel")]
    public class Hotel

    {
        public int HotelId { get; set; }
        [Display(Name = "IdHotel")]
        [Required]
        [StringLength(100)]
        public string LocalHotel { get; set; }
        [Display(Name = "Local Hotel")]
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Display(Name = "Descricao")]
        [Required]
        [StringLength(100)]
        public string ValorHospedagem { get; set; }
    }
}
