using System;

namespace NewsSite.BL.Abstractions
{
    internal interface ISimplifiedService
    {
        NewsSiteContext Context { get; set; }

        IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfEntity);
    }
}
