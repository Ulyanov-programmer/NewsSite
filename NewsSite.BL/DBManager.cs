using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using NewsSite.BL.Servies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.BL
{
    public static class DBManager
    {
        public static async Task<bool> AddEntity(NewsSiteContext context, IDTOModel dTOModel)
        {
            var service = new FullDataBaseService(context);

            await service.AddEntityToDb(dTOModel);

            return true;
        }

        //public static IDTOModel ReturnEntity(NewsSiteContext context, IDTOModel inputInfoNodel)
        //{
        //    var service = new SimplifiedDataBaseService(context);

        //    var modelFromDb = service.ReturnEntityFromDb(inputInfoNodel);

        //    return modelFromDb;
        //}

        public static IDTOModel ReturnEntity(NewsSiteContext context, string nameOfEntity, Type typeOfEntity)
        {
            var service = new SimplifiedDataBaseService(context);

            var modelFromDb = service.ReturnEntityFromDb(nameOfEntity, typeOfEntity);

            return modelFromDb;
        }
    }
}
