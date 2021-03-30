using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.BlazorUI.Data
{
    public class AddNewsVM
    {
        [Required(ErrorMessage = "Добавьте файл с содержимым новости!")]
        public IFormFile DocFile { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Длина названия статьи должна быть от 5 до 30 символов!")]
        public string NameOfNews { get; set; }

        [Required(ErrorMessage = "Не указано имя автора!")]
        public string NameOfAuhtor { get; set; }
    }
}
