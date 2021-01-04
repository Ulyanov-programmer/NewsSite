using System.ComponentModel.DataAnnotations;

namespace NewsSite.UI.ViewModels
{
    public class RegistrationVM
    {
        [Required(ErrorMessage = "Вы не указали своё имя!")]
        public string NameOfUser { get; set; }

        [Required(ErrorMessage = "Вы не указали ваш адрес электронной почты!")]
        [EmailAddress]
        public string EmailOfuser { get; set; }

        [Required(ErrorMessage = "Повторите ваш адрес электронной почты!")]
        [Compare("EmailOfuser", ErrorMessage = "Адреса электронной почты не совпадают")]
        public string EmailOfuserConfirm { get; set; }
    }
}
