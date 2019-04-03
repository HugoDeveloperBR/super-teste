using Microsoft.AspNetCore.Mvc;
using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Services;
using SuperTest.Web.Models.Usuarios;

namespace SuperTest.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public AccountController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var command = new AutenticarUsuarioCommand(model.Email, model.Senha);
                bool ehValido = _usuarioService.AutenticarUsuario(command);

                if(!ehValido)
                {
                    foreach(var notification in _usuarioService.Notifications)
                    {
                        //TODO: Apresentar notificaçoes
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioModel model)
        {
            if(ModelState.IsValid)
            {
                var command = new CadastrarNovoUsuarioCommand(model.Nome, model.Email, model.CPF, model.Senha);
                _usuarioService.CadastrarUsuario(command);

                bool ehValido = _usuarioService.HasNotification;
                if(!ehValido)
                {
                    foreach (var notification in _usuarioService.Notifications)
                    {
                        //TODO: Apresentar notificaçoes
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            model.UsuarioCadastrado = true;
            return RedirectToAction("Index", "Home");
        }
    }
}
