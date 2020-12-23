using System;
using System.Collections.Generic;

namespace NewsSite.BL.Abstractions
{
    internal interface IDbObject
    {
        int Identity
        {
            get;
        }
        string Name
        {
            get;
        }
    }
}
