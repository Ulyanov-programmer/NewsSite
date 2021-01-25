using NewsSite.BL;
using NewsSite.Tests.ViewModelsMosks.Mosks;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.Tests.TestSupportClasses
{
    internal class MoskLog : Log
    {
        internal MoskLog(InitializationVariants initVariant, string nameOfController, string nameOfMethod, string message, bool result = true)
                       : base(nameOfController, nameOfMethod, message, result)
        {
            InitVariant = initVariant;
        }

        internal MoskLog(InitializationVariants initVariant, Log log)
                       : base(log.NameOfController, log.NameOfMethod, log.Message, log.Result)
        {
            InitVariant = initVariant;
        }

        internal readonly InitializationVariants InitVariant;
    }
}
