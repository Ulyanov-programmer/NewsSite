using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    internal interface IUser
    {
        //string NameOfRole { get; }

        string Email { get; set; }
    }
}
