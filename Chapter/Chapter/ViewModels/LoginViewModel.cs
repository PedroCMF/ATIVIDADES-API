using System.ComponentModel.DataAnnotations;

namespace Chapter.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail necessario")] //É feito o requerimento usando a tabela Usuario da pasta Models, se o email for vazio retorna o erro. 

        public string Email { get; set;}

        [Required(ErrorMessage = "E-mail necessario")] //É feito o requerimento, se a senha for vazio retorna o erro.
        public string Senha { get; set;}

    }
}
