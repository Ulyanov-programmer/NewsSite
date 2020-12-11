using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    internal interface IService
    {
        NewsSiteContext Context { get; set; }

        internal IDbObject AddEntityToDb();

        internal IDTOModel ReturnEntityFromDb();
    }
}
