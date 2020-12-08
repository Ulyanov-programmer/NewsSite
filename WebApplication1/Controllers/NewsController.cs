using Microsoft.AspNetCore.Mvc;
using NewsSite.BL.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.UI.Controllers
{
    public class NewsController : Controller, IAppController
    {
        public IActionResult Watch()
        {
            return View();
        }

        public IActionResult AddNews()
        {
            return View();
        }

        IActionResult IAppController.RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
