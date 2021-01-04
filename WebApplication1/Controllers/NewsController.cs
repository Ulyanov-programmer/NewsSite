using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using NewsSite.UI.ViewModels;
using System.Threading.Tasks;

namespace NewsSite.UI.Controllers
{
    public class NewsController : Controller, IAppController
    {
        public NewsSiteContext Context { get; }

        public IWebHostEnvironment HostingEnvironment { get; }

        public NewsController(NewsSiteContext context, IWebHostEnvironment hostingEnvironment)
        {
            Context = context;
            HostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Watch(string newsName)
        {
            var newsDTO = Manager.ReturnEntity(Context, newsName, typeof(DTONews)) as DTONews;

            var paragraphs = new DTONews_Text(newsDTO.GetNameOfDoc());

            return View(paragraphs);
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
                var author = Manager.ReturnEntity(Context, model.NameOfAuhtor, typeof(DTOUser));
                var news = new DTONews(author as DTOUser, model.NameOfNews, model.DocFile.FileName);

                await Manager.AddEntity(Context, news);
                await FileManager.SaveFileOfNews(model.DocFile, news.GetPathToDocument());
            }

            return RedirectToHomePage();
        }

        private IActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
