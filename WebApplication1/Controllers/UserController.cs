using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using NewsSite.BL.Managers;
using NewsSite.UI.ViewModels;
using System.Threading.Tasks;

namespace NewsSite.UI.Controllers
{
    public class UserController : Controller, IAppController
    {
        public IWebHostEnvironment HostingEnvironment { get; }

        public UserController(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            IDTOModel userDTO = new DTOUser(model.NameOfUser, model.EmailOfuser);

            await new FullDBManager().AddEntityToDb(userDTO);

            return RedirectToHomePage();
        }


        private IActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
