using NewsSite.Tests.EntitiesMosks.Mosks;
using NewsSite.Tests.ViewModelsMosks.Mosks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.Tests.EntitiesMosks.Data
{
    class DbUser_Data : IEnumerable, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new DbUser_Mosk(InitializationVariants.Good) };
            yield return new object[] { new DbUser_Mosk(InitializationVariants.Null) };
            yield return new object[] { new DbUser_Mosk(InitializationVariants.Empty) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
