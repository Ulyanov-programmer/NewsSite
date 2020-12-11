using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    internal interface ISimplifiedService
    {
        NewsSiteContext Context { get; set; }

        public IDTOModel ReturnEntityFromDb();
    }
}
