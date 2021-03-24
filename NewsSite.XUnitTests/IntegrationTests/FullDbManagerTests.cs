using NewsSite.BL.DTOModels;
using NewsSite.BL.Managers;
using NewsSite.Tests.Abstractions;
using NewsSite.Tests.EntitiesMosks.Data;
using NewsSite.Tests.EntitiesMosks.Mosks;
using NewsSite.Tests.TestSupportClasses;
using Xunit;

namespace NewsSite.Tests.IntegrationTests
{
    public class FullDbManagerTests
    {
        const string TestConnectionString = "TestConnection";
        [Theory]
        [ClassData(typeof(DbNews_Data))]
        internal void AddEntityToDb_Test(DbNews_Mosk dbNews_Mosk)
        {
            //Arrange
            /*
                Before running this test, make sure that there is at least one copy 
                in the Users table and that its ID matches the ID used by dbNews_Mosk.
            */
            var fullDBManager = new FullDBManager(TestConnectionString);

            //Act
            var log = fullDBManager.AddEntityToDb(dbNews_Mosk.DbNewsObject).Result;
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

        [Theory]
        [ClassData(typeof(DbUser_Data))]
        internal void ReturnEntityFromDb_Test(DbUser_Mosk dbUser_Mosk)
        {
            //Arrange
            var fullDBManager = new FullDBManager(TestConnectionString);

            var taskLog = fullDBManager.AddEntityToDb(dbUser_Mosk.DbUserObject).Result;


            if (dbUser_Mosk.InitVariant == InitializationVariants.Good)
            {
                Assert.True(taskLog.Result, "The AddEntityToDb method taskLog.Result must be true, which means that an object has been added!");
            }

            //Act
            var returnedDTO = fullDBManager.ReturnEntityOrNullDTOFromDb(dbUser_Mosk.DbUserObject.Name, typeof(DTOUser));
            
            //Assert
            switch (dbUser_Mosk.InitVariant)
            {
                #region GoodVariant

                case InitializationVariants.Good:

                    Assert.True(dbUser_Mosk.Equals(returnedDTO),
                        "The MoskLog should Result.True because InitializationVariants is Good and the method must be executed.");
                    break;

                #endregion

                #region NullVariant

                case InitializationVariants.Null:

                    Assert.False(dbUser_Mosk.Equals(returnedDTO),
                        "The MoskLog should Result.False because InitializationVariants is Null and the method should not be executed.");
                    break;

                #endregion

                #region EmptyVariant

                case InitializationVariants.Empty:

                    Assert.False(dbUser_Mosk.Equals(returnedDTO),
                        "The Equals should false because InitializationVariants is Empty and the method should not be executed.");
                    break;

                    #endregion
            }
        }
    }
}
