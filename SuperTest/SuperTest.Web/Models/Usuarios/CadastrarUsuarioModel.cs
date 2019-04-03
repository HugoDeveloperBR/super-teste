using System.ComponentModel.DataAnnotations;

namespace SuperTest.Web.Models.Usuarios
{
    public class CadastrarUsuarioModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CPF é obrigatório")]
        public string CPF { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public bool UsuarioCadastrado { get; set; }
    }
}
