using System;
using System.Threading.Tasks;

namespace NewsSite.BL.Abstractions
{
    /// <summary>
    /// Представляет абстракцию класса, имеющего доступ к базе данных, содержащего полный для этого функционал.
    /// </summary>
    internal interface IDbManager
    {
        /// <summary>
        /// Объект контекста, необходимый для доступа к данным БД.
        /// </summary>
        NewsSiteContext Context { get; }

        /// <summary>
        /// Добавляет сущность в базу данных на основе параметров входного IDTOModel. 
        /// </summary>
        /// <param name="inputDTO"> Объект IDTOModel, параметры которого 
        ///                         будут основой для добавляемого объекта. </param>
        /// <returns> Task(bool), Result которого true, если операция добавления была успешно выполнена. </returns>
        Task<bool> AddEntityToDb(IDTOModel inputDTO);

        /// <summary>
        /// Возвращает сущность из БД, проводя поиск по входному значению его имени
        /// (по параметру Name, имеющегося у имплементаторов IDbObject).
        /// </summary>
        /// <param name="nameOfEntity"> Имя искомой сущности (в базе данных будет проводится поиск по столбцу Name). </param>
        /// <param name="typeOfEntity"> Тип искомой сущности. </param>
        /// <returns> Объект IDTOModel с данными о найденной сущности. </returns>
        IDTOModel ReturnEntityFromDb(string nameOfEntity, Type typeOfEntity);
    }
}
