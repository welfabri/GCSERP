using System.ComponentModel.DataAnnotations;

namespace GCS.ERP.Identidade.Aplicacao.ViewModels
{
    public class ViewModelUsuarioRegistro
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeCompleto { get; set; }

        [Display(Name ="Cargo")]
        public string Cargo { get; set; }
    }
}
