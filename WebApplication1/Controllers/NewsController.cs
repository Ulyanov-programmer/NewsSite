using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NewsSite.BL;
using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using NewsSite.BL.Managers;
using NewsSite.UI.ViewModels;
using System.Threading.Tasks;

namespace NewsSite.UI.Controllers
{
    public class NewsController : Controller, IAppController
    {
        public IWebHostEnvironment HostingEnvironment { get; }

        public NewsController(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Watch(string newsName)
        {
            var newsDTO = new SimplifiedDBManager().ReturnEntityFromDb(newsName, typeof(DTONews)) as DTONews;

            var watchModel = new DTONews_Text(newsDTO.GetNameOfDoc(), newsName);

            return View(watchModel);
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
                var author = new FullDBManager().ReturnEntityOrNullDTOFromDb(model.NameOfAuhtor, typeof(DTOUser));

                var news = new DTONews(author as DTOUser, model.NameOfNews, model.DocFile.FileName);

                //TODO: Сделать эти операции параллельными.
                await new FullDBManager().AddEntityToDb(news);
                await FileManager.SaveFileOfNews(model.DocFile);
            }

            return RedirectToHomePage();
        }

        private IActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
