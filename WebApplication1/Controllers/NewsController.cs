using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using NewsSite.BL.Servies;
using NewsSite.UI.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.UI.Controllers
{
    public class NewsController : Controller, IAppController
    {
        public NewsSiteContext Context { get; }

        public NewsController(NewsSiteContext context)
        {
            Context = context;
        }

        public IActionResult Watch()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNews(AddNewsVM model)
        {
            if (ModelState.IsValid)
            {
                var author = DBManager.ReturnEntity(Context, model.NameOfAuhtor, typeof(DTOUser));

                await DBManager.AddEntity(Context, author);
                await FileManager.SaveFile(model.DocFile);
            }

            return RedirectToHomePage();
        }

        IActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
