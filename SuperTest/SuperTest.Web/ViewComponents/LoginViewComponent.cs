using Microsoft.AspNetCore.Mvc;
using SuperTest.Web.Models.Usuarios;

namespace SuperTest.Web.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            LoginModel model = new LoginModel();

            return View(model);
        }
    }
}
