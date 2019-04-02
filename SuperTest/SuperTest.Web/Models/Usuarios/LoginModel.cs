using System.ComponentModel.DataAnnotations;

namespace SuperTest.Web.Models.Usuarios
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
