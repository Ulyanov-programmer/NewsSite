﻿using NewsSite.Tests.TestSupportClasses;

namespace NewsSite.Tests.Abstractions
{
    internal enum InitializationVariants
    {
        Good,
        Null,
        Empty
    }

    /// <summary>
    /// Абстрактный класс, содержащий общие свойства для Mosk-объектов.
    /// </summary>
    internal abstract class MockObject
    {
        /// <summary>
        /// Объект, логирующий результат работы этого наследника MoskObject.
        /// </summary>
        internal MockLog MockLog { get; set; }

        /// <summary>
        /// Вариант инициализации наследника MoskObject. От него зависит, какие данные будут присвоены полям.
        /// </summary>
        internal readonly InitializationVariants InitVariant;

        /// <summary>
        /// Инициализирует поля наследника MoskObject на основе входных аргументов.
        /// </summary>
        /// <param name="initVariant"> Вариант инициализации наследника MoskObject. </param>
        protected MockObject(InitializationVariants initVariant)
        {
            InitVariant = initVariant;
        }
    }
}
