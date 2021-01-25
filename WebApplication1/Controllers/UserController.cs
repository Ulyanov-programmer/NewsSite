using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using NewsSite.UI.ViewModels;
using System.Threading.Tasks;

namespace NewsSite.UI.Controllers
{
    public class UserController : Controller, IAppController
    {
        public NewsSiteContext Context { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        public UserController(NewsSiteContext context, IWebHostEnvironment hostingEnvironment)
        {
            Context = context;
            HostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            IDTOModel userDTO = new DTOUser(model.NameOfUser, model.EmailOfuser);

            var operManager = new OperationManager();

            await operManager.AddEntity(Context, userDTO);
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        private IActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
