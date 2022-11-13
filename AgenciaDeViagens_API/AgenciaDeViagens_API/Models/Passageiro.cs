using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViagens_API.Models
{
    [Table("Passageiro")]
    public class Passageiro

    {
        public int PassageiroId { get; set; }
        [Display(Name = "IdPassageiro")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Display(Name = "Nome")]
        [Required]
        [StringLength(80)]
        public string Rg { get; set; }
        [Display(Name = "Rg")]
        [Required]
        [StringLength(15)]
        public string Cpf { get; set; }
        [Display(Name = "Cpf")]
        [Required]
        [StringLength(15)]
        public string DataNascimento { get; set; }
        [Display(Name = "Data Nascimento")]
        [Required]
        public string Endereco { get; set; }
        [Display(Name = "Endereco")]
        [Required]
        public string Complemento { get; set; }
        [Display(Name = "Complemento")]
        [Required]
        public string Cep { get; set; }
        [Display(Name = "Cep")]
        [Required]
        public string Estado { get; set; }
        [Display(Name = "Estado")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Telefone { get; set; }
    }
}
