using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagens_API.Models
{
    [Table("Voo")]
    public class Voo

    {
        public int VooId { get; set; }
        [Display(Name = "IdVoo")]
        [Required]
        [StringLength(100)]
        public string Origem { get; set; }
        [Display(Name = "Origem")]
        [Required]
        [StringLength(100)]
        public string Destino { get; set; }
        [Display(Name = "Destino")]
        [Required]
        [StringLength(100)]
        public string Partida { get; set; }
        [Display(Name = "Data de Partida")]
        [Required]
        [StringLength(100)]
        public string Chegada { get; set; }
        [Display(Name = "Data de Chegada")]
        [Required]
        [StringLength(100)]
        public string ValorVoo { get; set; }
        [Display(Name = "Valor Voo")]
        [Required]
        public int Paradas { get; set; }
    }
}
