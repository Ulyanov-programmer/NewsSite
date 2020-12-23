using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewsSite.BL.Abstractions;

namespace NewsSite.BL.DbModels
{
    public class DbNews : IDbObject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DbNews(int authorId, string nameOfNews, string pathToDocument)
        {
            DbUserId = authorId;
            Name = nameOfNews;
            PathToDocument = pathToDocument;
        }

        public DbNews() { }


        public string PathToDocument { get; set; }

        public int DbUserId { get; set; }
        public DbUser DbUser { get; set; }
    }
}
