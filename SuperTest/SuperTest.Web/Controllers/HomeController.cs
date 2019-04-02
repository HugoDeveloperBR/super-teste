using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SuperTest.Domain.Services;
using SuperTest.Web.Models;
using SuperTest.Web.Models.Usuarios;

namespace SuperTest.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public HomeController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
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
