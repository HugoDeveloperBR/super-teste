using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperTest.ApplicationService;
using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Web.Models;

namespace SuperTest.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            UsuarioAppService usuarioAppService = new UsuarioAppService();
            usuarioAppService.CadastrarUsuario(new CadastrarNovoUsuarioCommand("", "", "40225701804", "123"));

            if(usuarioAppService.HasNotification)
                return View();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
