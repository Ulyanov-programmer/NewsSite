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
        internal void OperationManager_AddEntity_Test(DbNews_Mosk dbNews_Mosk)
        {
            //Arrange
            using var context = new NewsSiteContext(GetDbContextOptions());
            var operManager = new OperationManager();

            //Act
            var log = operManager.AddEntity(context, dbNews_Mosk.DbNewsObject).Result;
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

        public static DbContextOptions<NewsSiteContext> GetDbContextOptions()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                //Enter your path to the appsettings.json file for this project below.
                .SetBasePath(@"")
                .AddJsonFile("appsettings.json")
                .Build();


            return new DbContextOptionsBuilder<NewsSiteContext>()
                  //Enter the connection string from appsettings.json below.
                  .UseSqlServer(new SqlConnection(configuration.GetConnectionString("DefaultConnection"))).Options;

        }
    }
}
