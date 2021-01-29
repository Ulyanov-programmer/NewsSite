using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller, IAppController
    {
        public IWebHostEnvironment HostingEnvironment { get; }

        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var operManager = new OperationManager();

            var lastNews = operManager.ReturnEntities(5);
            return View(lastNews);
        }

        //IActionResult RedirectToHomePage()
        //{
        //    return RedirectToAction("Index");
        //}
    }
}
