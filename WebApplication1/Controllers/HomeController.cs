using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;

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
            var lastNews = OperationManager.ReturnEntities(Context, 5);
            return View(lastNews);
        }

        //IActionResult RedirectToHomePage()
        //{
        //    return RedirectToAction("Index");
        //}
    }
}
