using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace NewsSite.BL.Abstractions
{
    /// <summary>
    /// Абстрактный класс, содержащий общий функционал для Manager-классов. 
    /// </summary>
    public abstract class DbManager
    {
        /// <summary>Читает файл appsettings.json и создаёт на основе данных в нём объект DbContextOptions,
        /// необходимый для создания объекта контекста.</summary>
        /// <param name="connectionString">Строка подключения (её название) из файла appsettings.json. По умолчанию использует строку к основной БД.</param>
        protected DbContextOptions<NewsSiteContext> GetDbContextOptions(string connectionString = "DefaultConnection")
        {
            // Specifies the fully qualified path to the directory of the appsettings.json file.
            string pathToAppsettingsDir = Path.GetFullPath(@"NewsSite\WebApplication1\", AppDomain.CurrentDomain.BaseDirectory
                                              .Remove(AppDomain.CurrentDomain.BaseDirectory.IndexOf("NewsSite")));
            #region Easy to read version. 

            /* The first argument is the directory where appsettings.json is located, 
               the second is the full path to that directory. */

            //string basePath = AppDomain.CurrentDomain.BaseDirectory;
            //basePath = basePath.Remove(basePath.IndexOf("NewsSite."));

            //string relativePath = @"WebApplication1\";

            //string pathToAppsettingsDir = Path.GetFullPath(relativePath, basePath);

            #endregion

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(pathToAppsettingsDir)
                .AddJsonFile("appsettings.json")
                .Build();


            return new DbContextOptionsBuilder<NewsSiteContext>()
                  //Enter a connection string from appsettings.json below.
                  .UseSqlServer(new SqlConnection(configuration.GetConnectionString(connectionString))).Options;
        }

        #region Logging

        /// <summary>
        /// Создаёт объект Log, содержащий данные о результате работы метода.
        /// </summary>
        /// <param name="nameOfController"> Имя класса, метод которого был завершён. </param>
        /// <param name="nameOfMethod"> Имя метода, который был завершён. </param>
        /// <param name="ex"> Произошедшее в результате работы исключение. </param>
        /// <returns></returns>
        protected Log WriteLog(string nameOfController, string nameOfMethod, Exception ex)
        {
            return new Log(nameOfController, nameOfMethod, ex.InnerException.Message);
        }

        /// <summary>
        /// Создаёт объект Log, содержащий данные о результате работы метода.
        /// </summary>
        /// <param name="nameOfController"> Имя класса, метод которого был завершён. </param>
        /// <param name="nameOfMethod"> Имя метода, который был завершён. </param>
        /// <returns></returns>
        /// <remarks>
        /// В созданном объекте Log результат будет описан, как положительный. Если вы хотите описать другой случай,
        /// обратитесь к перегрузке метода, принимающей объект Exception.
        /// </remarks>
        protected Log WriteLog(string nameOfController, string nameOfMethod)
        {
            return new Log(nameOfController, nameOfMethod, "The method completed successfully", true);
        }

        #endregion
    }
}
