using Microsoft.AspNetCore.Mvc;
using NewsSite.BL.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.UI.Controllers
{
    public class UserController : Controller, IAppController
    {
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

        IActionResult IAppController.RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
