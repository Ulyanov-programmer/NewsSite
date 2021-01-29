using System;

namespace NewsSite.BL.Abstractions
{
    /// <summary>
    /// Представляет абстракцию класса, имеющего доступ к базе данных, содержащего полный для этого функционал.
    /// </summary>
    internal interface ISimplifiedDbManager
    {
        /// <summary>
        /// Возвращает сущность из БД, проводя поиск по входному значению его имени
        /// (по параметру Name, имеющегося у имплементаторов IDbObject).
        /// </summary>
        /// 
        /// <param name="nameOfEntity"> Имя искомой сущности (в базе данных будет проводится поиск по столбцу Name). </param>
        /// <param name="typeOfEntity"> Тип искомой сущности. </param>
        /// 
        /// <returns> Объект IDTOModel с данными о найденной сущности. </returns>
        IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfEntity);
    }
}
