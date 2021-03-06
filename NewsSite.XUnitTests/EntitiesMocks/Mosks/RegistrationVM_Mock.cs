﻿using NewsSite.Tests.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace NewsSite.Tests.ViewModelsMosks.Mosks
{
    internal class RegistrationVM_Mock
    {
        internal RegistrationVM_Mock(InitializationVariants variant)
        {
            switch (variant)
            {
                case InitializationVariants.Good:

                    NameOfUser = "NameOfUser";
                    EmailOfuser = "EmailOfuser";
                    EmailOfuserConfirm = EmailOfuser;

                    break;
                case InitializationVariants.Null:

                    NameOfUser = null;
                    EmailOfuser = null;
                    EmailOfuserConfirm = null;

                    break;
                case InitializationVariants.Empty:

                    NameOfUser = string.Empty;
                    EmailOfuser = string.Empty;
                    EmailOfuserConfirm = string.Empty;

                    break;
                default:
                    break;
            }
        }

        [Required(ErrorMessage = "Вы не указали своё имя!")]
        public string NameOfUser { get; set; }

        [Required(ErrorMessage = "Вы не указали ваш адрес электронной почты!")]
        [EmailAddress]
        public string EmailOfuser { get; set; }

        [Required(ErrorMessage = "Повторите ваш адрес электронной почты!")]
        [EmailAddress]
        [Compare("EmailOfuser", ErrorMessage = "Адреса электронной почты не совпадают")]
        public string EmailOfuserConfirm { get; set; }
    }
}
