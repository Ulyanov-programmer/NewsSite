using NewsSite.BL.DbModels;
using NewsSite.Tests.TestSupportClasses;
using System;
using System.Text;

namespace NewsSite.Tests.ViewModelsMosks.Mosks
{
    class DbNews_Mosk
    {
        internal MoskLog MoskLog { get; set; }

        internal readonly InitializationVariants InitVariant;

        internal DbNews DbNewsObject = new DbNews();

        internal DbNews_Mosk(InitializationVariants variant)
        {
            switch (variant)
            {
                case InitializationVariants.Good:

                    DbNewsObject.Id = 0;
                    DbNewsObject.Name = $"NewsFrom{DateTime.Now}";
                    DbNewsObject.PathToDocument = $@"TestFiles\{DbNewsObject.Name}.txt";
                    DbNewsObject.DbUserId = 1;
                    InitVariant = variant;

                    break;
                case InitializationVariants.Null:

                    DbNewsObject.Id = 0;
                    DbNewsObject.Name = null;
                    DbNewsObject.PathToDocument = null;
                    DbNewsObject.DbUserId = 0;
                    InitVariant = variant;

                    break;
                case InitializationVariants.Empty:

                    DbNewsObject.Id = 0;
                    DbNewsObject.Name = string.Empty;
                    DbNewsObject.PathToDocument = string.Empty;
                    DbNewsObject.DbUserId = 0;
                    InitVariant = variant;

                    break;
                default:
                    break;
            }
        }
    }
}