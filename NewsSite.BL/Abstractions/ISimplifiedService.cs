using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    interface ISimplifiedService
    {
        NewsSiteContext Context { get; set; }

        IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfEntity);
    }
}
