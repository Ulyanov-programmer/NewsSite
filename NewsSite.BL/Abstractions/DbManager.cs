using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewsSite.BL.Abstractions
{
    public abstract class DbManager
    {
        protected DbContextOptions<NewsSiteContext> GetDbContextOptions()
        {
            /* Specifies the fully qualified path to the directory of the appsettings.json file.
               The first argument is the directory where appsettings.json is located, 
               the second is the full path to that directory. */

            string pathToAppsettingsDir = Path.GetFullPath(@"NewsSite\WebApplication1\", AppDomain.CurrentDomain.BaseDirectory
                                              .Remove(AppDomain.CurrentDomain.BaseDirectory.IndexOf("NewsSite")));
            #region Easy to read version. 

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
                  //Enter the connection string from appsettings.json below.
                  .UseSqlServer(new SqlConnection(configuration.GetConnectionString("DefaultConnection"))).Options;
        }

        #region Logging

        protected Log WriteLog(string nameOfController, string nameOfMethod, Exception ex)
        {
            return new Log(nameOfController, nameOfMethod, ex.InnerException.Message);
        }

        protected Log WriteLog(string nameOfController, string nameOfMethod)
        {
            return new Log(nameOfController, nameOfMethod, "The method completed successfully", true);
        }

        #endregion
    }
}
