using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    internal interface IUser
    {
        Role Role { get; }

        string Email { get; set; }
    }
}
