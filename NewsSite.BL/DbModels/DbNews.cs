using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NewsSite.BL.Abstractions;

namespace NewsSite.BL.DbModels
{
    internal class DbNews : IDbObject
    {
        [Key]
        public int NewsId { get; set; }
        public int Identity
        {
            get => NewsId;
        }

        private string NameOfNews { get; set; }

        public DbNews(string nameOfNews, string pathToDocument)
        {
            NameOfNews = nameOfNews;
            PathToDocument = pathToDocument;
        }

        public DbNews() { }

        public string Name
        {
            get => NameOfNews;
            set => throw new NotImplementedException();
        }

        public string PathToDocument { get; set; }

        public int UserId { get; set; }
        public DbUser DbUserId { get; set; }
    }
}
