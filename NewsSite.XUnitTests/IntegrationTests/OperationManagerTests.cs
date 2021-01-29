using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewsSite.BL;
using NewsSite.Tests.ViewModelsMosks.Data;
using NewsSite.Tests.ViewModelsMosks.Mosks;
using System;
using Microsoft.Extensions.Configuration.FileExtensions;
using System.IO;
using Xunit;
using NewsSite.Tests.TestSupportClasses;

namespace NewsSite.Tests.IntegrationTests
{
    public class OperationManagerTests
    {
        [Theory]
        [ClassData(typeof(DbNews_Data))]
        internal void AddEntity_Test(DbNews_Mosk dbNews_Mosk)
        {
            //Arrange
            using var context = new NewsSiteContext(GetDbContextOptions());
            var operManager = new OperationManager();

            //Act
            var log = operManager.AddEntity(dbNews_Mosk.DbNewsObject).Result;
            dbNews_Mosk.MoskLog = new MoskLog(dbNews_Mosk.InitVariant, log);

            //Assert
            switch (dbNews_Mosk.InitVariant)
            {
                case InitializationVariants.Good:

                    Assert.True(dbNews_Mosk.MoskLog.Result,
                        "The MoskLog should Result.True because InitializationVariants is Good and the method must be executed.");
                    break;

                case InitializationVariants.Null:

                    Assert.False(dbNews_Mosk.MoskLog.Result,
                        "The MoskLog should Result.False because InitializationVariants is Null and the method should not be executed.");
                    break;

                case InitializationVariants.Empty:

                    Assert.False(dbNews_Mosk.MoskLog.Result,
                        "The MoskLog should Result.False because InitializationVariants is Empty and the method should not be executed.");
                    break;
            }
        }

        //TODO: Убрать копирование этого метода в нескольких классах.
        private static DbContextOptions<NewsSiteContext> GetDbContextOptions()
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
    }
}
