using NewsSite.Tests.Abstractions;
using NewsSite.Tests.EntitiesMosks.Mosks;
using System.Collections;
using System.Collections.Generic;

namespace NewsSite.Tests.EntitiesMosks.Data
{
    internal class DbNews_Data : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new DbNews_Mosk(InitializationVariants.Good) };
            yield return new object[] { new DbNews_Mosk(InitializationVariants.Null) };
            yield return new object[] { new DbNews_Mosk(InitializationVariants.Empty) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
