using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsSite.BL.Abstractions
{
    interface IService
    {
        NewsSiteContext Context { get; }

        Task<bool> AddEntityToDb(IDTOModel inputDTO);

        IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfEntity);
    }
}
