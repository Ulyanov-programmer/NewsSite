using Microsoft.EntityFrameworkCore;
using NewsSite.BL.Abstractions;
using NewsSite.BL.Managers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsSite.BL
{
    /// <summary>
    /// Класс, выполняющий функции передачи данных из слоя интерфейса в бизнес-логику и обратно.
    /// </summary>
    public class OperationManager : ILogger
    {
        public async Task<bool> AddEntity(IDTOModel dtoModel)
        {
            var service = new FullDBManager();

            await service.AddEntityToDb(dtoModel);

            return true;
        }

        public async Task<Log> AddEntity(IDbObject dbObject)
        {
            var service = new FullDBManager();
            
            var log = await service.AddEntityToDb(dbObject);

            if (log.Result is false){
                return log;
            }
            else{
                return WriteLog("OperationManager", "AddEntity");
            }
        }

        public IEnumerable<IDTOModel> ReturnEntities(int count, bool lastEntities = true)
        {
            var service = new SimplifiedDBManager();

            var modelFromDb = service.ReturnMultipleNews(count, lastEntities);

            return modelFromDb;
        }

        public IDTOModel ReturnEntity(string nameOfEntity, Type typeOfEntity)
        {
            var service = new SimplifiedDBManager();

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
