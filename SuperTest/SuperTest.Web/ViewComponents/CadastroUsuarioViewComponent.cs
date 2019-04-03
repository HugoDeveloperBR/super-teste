using Microsoft.AspNetCore.Mvc;
using SuperTest.Web.Models.Usuarios;

namespace SuperTest.Web.ViewComponents
{
    public class CadastroUsuarioViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CadastrarUsuarioModel model = new CadastrarUsuarioModel();

            return View(model);
        }
    }
}
