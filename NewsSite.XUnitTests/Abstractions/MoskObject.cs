using NewsSite.BL.DbModels;
using NewsSite.Tests.TestSupportClasses;
using NewsSite.Tests.ViewModelsMosks.Mosks;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.Tests.Abstractions
{
    abstract class MoskObject
    {
        internal MoskLog MoskLog { get; set; }

        internal readonly InitializationVariants InitVariant;

        protected MoskObject(InitializationVariants initVariant)
        {
            InitVariant = initVariant;
        }
    }
}
