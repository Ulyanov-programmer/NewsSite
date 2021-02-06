using NewsSite.BL.Abstractions;
using NewsSite.BL.DTOModels;
using NewsSite.Entities.DbModels;
using NewsSite.Tests.Abstractions;
using NewsSite.Tests.ViewModelsMosks.Mosks;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSite.Tests.EntitiesMosks.Mosks
{
    class DbUser_Mosk : MoskObject
    {
        internal readonly DbUser DbUserObject = new DbUser();

        internal DbUser_Mosk(InitializationVariants variant) : base(variant)
        {
            switch (variant)
            {
                case InitializationVariants.Good:

                    DbUserObject = new DbUser($"User{Guid.NewGuid()}", $"myEmail{DbUserObject.Name}@yandex.ru");

                    break;
                case InitializationVariants.Null:

                    DbUserObject = new DbUser(null, null);

                    break;
                case InitializationVariants.Empty:

                    DbUserObject = new DbUser(string.Empty, string.Empty);

                    break;
            }
        }

        internal bool Equals(DbUser dbUser)
        {
            if (dbUser.Id == DbUserObject.Id &&
                dbUser.Name == DbUserObject.Name )
            {
                return true;
            }
            return false;
        }

        internal bool Equals(IDTOModel dtoModel)
        {
            if (dtoModel.Equals(DbUserObject))
            {
                return true;
            }
            return false;
        }
    }
}
