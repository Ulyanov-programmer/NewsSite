using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller, IAppController
    {
        public NewsSiteContext Context { get; }

        public HomeController(NewsSiteContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        IActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index");
        }
    }
}
