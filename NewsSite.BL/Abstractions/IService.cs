using System;
using System.Threading.Tasks;

namespace NewsSite.BL.Abstractions
{
    internal interface IService
    {
        NewsSiteContext Context { get; }

        Task<bool> AddEntityToDb(IDTOModel inputDTO);

        IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfEntity);
    }
}
