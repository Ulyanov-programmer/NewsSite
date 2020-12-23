using System;
using System.Collections.Generic;

namespace NewsSite.BL.Abstractions
{
    public interface IDbObject
    {
        int Id
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }
    }
}
