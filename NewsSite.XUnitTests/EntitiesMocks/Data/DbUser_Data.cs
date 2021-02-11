using NewsSite.Tests.Abstractions;
using NewsSite.Tests.EntitiesMosks.Mosks;
using System.Collections;
using System.Collections.Generic;

namespace NewsSite.Tests.EntitiesMosks.Data
{
    internal class DbUser_Data : IEnumerable, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new DbUser_Mock(InitializationVariants.Good) };
            yield return new object[] { new DbUser_Mock(InitializationVariants.Null) };
            yield return new object[] { new DbUser_Mock(InitializationVariants.Empty) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
