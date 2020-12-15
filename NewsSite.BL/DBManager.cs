using NewsSite.BL.Abstractions;
using NewsSite.BL.Servies;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.BL
{
    public static class DBManager
    {
        public static bool AddEntity(NewsSiteContext context, IDTOModel dTOModel)
        {
            var service = new FullDataBaseService(context);

            service.AddEntityToDb(dTOModel);

            return true;
        }

        public static IDTOModel ReturnEntity(NewsSiteContext context, IDTOModel inputInfoNodel)
        {
            var service = new SimplifiedDataBaseService(context);

            var modelFromDb = service.ReturnEntityFromDb(inputInfoNodel);

            return modelFromDb;
        }
    }
}
