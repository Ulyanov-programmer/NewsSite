using NewsSite.BL.Abstractions;
using NewsSite.BL.Servies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsSite.BL
{
    public static class Manager
    {
        public static async Task<bool> AddEntity(NewsSiteContext context, IDTOModel dTOModel)
        {
            var service = new FullDataBaseService(context);

            await service.AddEntityToDb(dTOModel);

            return true;
        }

        public static IEnumerable<IDTOModel> ReturnEntities(NewsSiteContext context,
                                                            int count,
                                                            bool lastEntities = true)
        {
            var service = new SimplifiedDataBaseService(context);

            var modelFromDb = service.ReturnMultipleNews(count, lastEntities);

            return modelFromDb;
        }

        public static IDTOModel ReturnEntity(NewsSiteContext context, string nameOfEntity, Type typeOfEntity)
        {
            var service = new SimplifiedDataBaseService(context);

            var modelFromDb = service.ReturnEntityFromDb(nameOfEntity, typeOfEntity);

            return modelFromDb;
        }
    }
}
