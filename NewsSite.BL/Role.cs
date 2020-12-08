using NewsSite.BL.Abstractions;
using NewsSite.BL.DbModels;
using System;
using System.Collections.Generic;

namespace NewsSite.BL
{
    internal class Role : IDbObject
    {
        readonly int Id;
        public int Identity
        {
            get => Id;
        }

        private string NameOfRole { get; set; }
        public string Name
        {
            get => NameOfRole;
            set => throw new NotImplementedException();
        }

        public List<DbUser> Users { get; set; }

    }
}
