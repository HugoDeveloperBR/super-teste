using Microsoft.AspNetCore.Mvc;
using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Services;
using SuperTest.Web.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
