using NewsSite.Tests.ViewModelsMosks.Mosks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.Tests.ViewModelsMosks
{
    internal class RegistrationVM_Data : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new RegistrationVM_Mosk(InitializationVariants.Good) };
            yield return new object[] { new RegistrationVM_Mosk(InitializationVariants.Null) };
            yield return new object[] { new RegistrationVM_Mosk(InitializationVariants.Empty) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
