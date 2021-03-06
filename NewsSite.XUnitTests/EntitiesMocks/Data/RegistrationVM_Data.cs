﻿using NewsSite.Tests.Abstractions;
using NewsSite.Tests.ViewModelsMosks.Mosks;
using System.Collections;
using System.Collections.Generic;

namespace NewsSite.Tests.ViewModelsMosks
{
    internal class RegistrationVM_Data : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new RegistrationVM_Mock(InitializationVariants.Good) };
            yield return new object[] { new RegistrationVM_Mock(InitializationVariants.Null) };
            yield return new object[] { new RegistrationVM_Mock(InitializationVariants.Empty) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
