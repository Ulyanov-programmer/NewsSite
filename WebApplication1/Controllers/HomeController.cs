using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using NewsSite.BL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller, IAppController
    {
        public NewsSiteContext Context { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        public HomeController(NewsSiteContext context, IWebHostEnvironment hostingEnvironment)
        {
            Context = context;
            HostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var lastNews = DBManager.ReturnEntities(Context, 10);
            return View(lastNews);
        }

        IActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index");
        }
    }
}
