using Microsoft.AspNetCore.Mvc;
using NewsSite.BL.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller, IAppController
    {

        public IActionResult Index()
        {
            return View();
        }

        IActionResult IAppController.RedirectToHomePage()
        {
            return RedirectToAction("Index");
        }
    }
}
