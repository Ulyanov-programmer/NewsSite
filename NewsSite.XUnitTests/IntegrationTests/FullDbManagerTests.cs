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
        internal void AddEntityToDb_Test(DbNews_Mock dbNews_Mock)
        {
            //Arrange
            /*
                Before running this test, make sure that there is at least one copy 
                in the Users table and that its ID matches the ID used by dbNews_Mosk.
            */
            var fullDBManager = new FullDBManager(TestConnectionString);

            //Act
            var log = fullDBManager.AddEntityToDb(dbNews_Mock.DbNewsObject).Result;
            dbNews_Mock.MockLog = new MockLog(dbNews_Mock.InitVariant, log);

            //Assert
            switch (dbNews_Mock.InitVariant)
            {
                #region GoodVariant

                case InitializationVariants.Good:

                    Assert.True(dbNews_Mock.MockLog.Result,
                        "The MockLog should Result.True because InitializationVariants is Good and the method must be executed.");
                    break;

                #endregion

                #region NullVariant

                case InitializationVariants.Null:

                    Assert.False(dbNews_Mock.MockLog.Result,
                        "The MockLog should Result.False because InitializationVariants is Null and the method should not be executed.");
                    break;

                #endregion

                #region EmptyVariant

                case InitializationVariants.Empty:

                    Assert.False(dbNews_Mock.MockLog.Result,
                        "The MockLog should Result.False because InitializationVariants is Empty and the method should not be executed.");
                    break;

                    #endregion
            }
        }

        [Theory]
        [ClassData(typeof(DbUser_Data))]
        internal void ReturnEntityFromDb_Test(DbUser_Mock dbUser_Mock)
        {
            //Arrange
            var fullDBManager = new FullDBManager(TestConnectionString);

            var taskLog = fullDBManager.AddEntityToDb(dbUser_Mock.DbUserObject).Result;


            if (dbUser_Mock.InitVariant == InitializationVariants.Good)
            {
                Assert.True(taskLog.Result, "The AddEntityToDb method taskLog.Result must be true, which means that an object has been added!");
            }

            //Act
            var returnedDTO = fullDBManager.ReturnEntityOrNullDTOFromDb(dbUser_Mock.DbUserObject.Name, typeof(DTOUser));
            
            //Assert
            switch (dbUser_Mock.InitVariant)
            {
                #region GoodVariant

                case InitializationVariants.Good:

                    Assert.True(dbUser_Mock.Equals(returnedDTO),
                        "The MockLog should Result.True because InitializationVariants is Good and the method must be executed.");
                    break;

                #endregion

                #region NullVariant

                case InitializationVariants.Null:

                    Assert.False(dbUser_Mock.Equals(returnedDTO),
                        "The MockLog should Result.False because InitializationVariants is Null and the method should not be executed.");
                    break;

                #endregion

                #region EmptyVariant

                case InitializationVariants.Empty:

                    Assert.False(dbUser_Mock.Equals(returnedDTO),
                        "The Equals should false because InitializationVariants is Empty and the method should not be executed.");
                    break;

                    #endregion
            }
        }
    }
}
