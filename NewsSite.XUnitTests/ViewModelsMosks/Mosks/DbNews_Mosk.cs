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

        internal readonly DbNews DbNewsObject = new DbNews();

        internal DbNews_Mosk(InitializationVariants variant)
        {
            switch (variant)
            {
                case InitializationVariants.Good:

                    DbNewsObject = new DbNews(1, $"NewsFrom{DateTime.Now}",
                                                 $@"TestFiles\{DbNewsObject.Name}.txt");

                    break;
                case InitializationVariants.Null:

                    DbNewsObject = new DbNews(0, null, null);

                    break;
                case InitializationVariants.Empty:

                    DbNewsObject = new DbNews(0, string.Empty, string.Empty);

                    break;
            }

            InitVariant = variant;
        }
    }
}