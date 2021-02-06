using NewsSite.Entities.DbModels;
using NewsSite.Tests.Abstractions;
using NewsSite.Tests.TestSupportClasses;
using NewsSite.Tests.ViewModelsMosks.Mosks;
using System;
using System.Text;

namespace NewsSite.Tests.EntitiesMosks.Mosks
{
    class DbNews_Mosk : MoskObject
    {
        internal readonly DbNews DbNewsObject = new DbNews();

        internal DbNews_Mosk(InitializationVariants variant) : base(variant)
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
        }
    }
}