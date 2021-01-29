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
            var operManager = new OperationManager();

            //Act
            var log = operManager.AddEntity(dbNews_Mosk.DbNewsObject).Result;
            dbNews_Mosk.MoskLog = new MoskLog(dbNews_Mosk.InitVariant, log);

            //Assert
            switch (dbNews_Mosk.InitVariant)
            {
                #region GoodVariant

                case InitializationVariants.Good:

                    Assert.True(dbNews_Mosk.MoskLog.Result,
                        "The MoskLog should Result.True because InitializationVariants is Good and the method must be executed.");
                    break;

                #endregion

                #region NullVariant

                case InitializationVariants.Null:

                    Assert.False(dbNews_Mosk.MoskLog.Result,
                        "The MoskLog should Result.False because InitializationVariants is Null and the method should not be executed.");
                    break;

                #endregion

                #region EmptyVariant

                case InitializationVariants.Empty:

                    Assert.False(dbNews_Mosk.MoskLog.Result,
                        "The MoskLog should Result.False because InitializationVariants is Empty and the method should not be executed.");
                    break;

                #endregion
            }
        }
    }
}
