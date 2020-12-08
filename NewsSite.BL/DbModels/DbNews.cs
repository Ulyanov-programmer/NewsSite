using System;
using System.Collections.Generic;
using Aspose.Words;
using NewsSite.BL.Abstractions;

namespace NewsSite.BL.DbModels
{
    internal class DbNews : IDbObject
    {
        readonly int Id;
        public int Identity
        {
            get => Id;
        }

        readonly string NameOfNews;

        public DbNews(string nameOfNews, string name, string pathToDocument)
        {
            NameOfNews = nameOfNews;
            Name = name;
            PathToDocument = pathToDocument;
        }

        public string Name
        {
            get => NameOfNews;
            set => throw new NotImplementedException();
        }

        public string PathToDocument { get; internal set; }
    }
}
