using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using NewsSite.UI.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.UI.Controllers
{
    public class UserController : Controller, IAppController
    {
        public NewsSiteContext Context { get; }

        public UserController(NewsSiteContext context)
        {
            Context = context;
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

            await DBManager.AddEntity(Context, userDTO);
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        IActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
