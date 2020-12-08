using System;
using System.Collections.Generic;

namespace NewsSite.DbModels.DbModels
{
    class User : IUser
    {
        public News News { get; set; }
    }
}
