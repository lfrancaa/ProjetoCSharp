using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagens_API.Models
{
    [Table("Passagem")]
    public class Passagem

    {
        public int PassagemId { get; set; }
        [Display(Name = "IdPassagem")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Display(Name = "Nome")]
        [Required]
        [StringLength(80)]
        public string NomeLocalOrigem { get; set; }
        [Display(Name = "Nome Local Origem")]
        [Required]
        public string NomeLocalDestino { get; set; }
        [Display(Name = "Nome Local Destino")]
        [Required]
        public string DataViagemIda { get; set; }
        [Display(Name = "Data Viagem Ida")]
        [Required]
        public string DataViagemVolta { get; set; }
    }
}
