using Microsoft.EntityFrameworkCore;
using NewsSite.BL.Abstractions;
using NewsSite.BL.Managers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsSite.BL
{
    /// <summary>
    /// Статический класс, выполняющий функции передачи данных из слоя интерфейса в бизнес-логику и обратно.
    /// </summary>
    public class OperationManager : ILogger
    {
        public async Task<bool> AddEntity(NewsSiteContext context, IDTOModel dtoModel)
        {
            var service = new FullDBManager(context);

            await service.AddEntityToDb(dtoModel);

            return true;
        }

        public async Task<Log> AddEntity(NewsSiteContext context, IDbObject dbObject)
        {
            var service = new FullDBManager(context);

            var log = await service.AddEntityToDb(dbObject);

            if (log.Result is false){
                return log;
            }
            else{
                return WriteLog("OperationManager", "AddEntity");
            }
        }

        public IEnumerable<IDTOModel> ReturnEntities(NewsSiteContext context, int count,
                                                                              bool lastEntities = true)
        {
            var service = new SimplifiedDBManager(context);

            var modelFromDb = service.ReturnMultipleNews(count, lastEntities);

            return modelFromDb;
        }

        public IDTOModel ReturnEntity(NewsSiteContext context, string nameOfEntity, Type typeOfEntity)
        {
            var service = new SimplifiedDBManager(context);

            var modelFromDb = service.ReturnEntityFromDb(nameOfEntity, typeOfEntity);

            return modelFromDb;
        }

        #region Logging

        public Log WriteLog(string nameOfController, string nameOfMethod, Exception ex)
        {
            return new Log(nameOfController, nameOfMethod, ex.InnerException.Message);
        }

        public Log WriteLog(string nameOfController, string nameOfMethod)
        {
            return new Log(nameOfController, nameOfMethod, "Methods completed successfully", true);
        }

        #endregion
        
    }
}
