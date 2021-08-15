using System.Collections;
using System.Collections.Generic;
using Domain.Common;
using Domain.Entities.BookEntities;

namespace Domain.Entities.AuthorEntities
{
    public class Author:BaseEntity<int>
    {
        public string Name { get; set; }

        #region Relations

        public ICollection<BookAuthor> BookAuthors { get; set; }

        #endregion


    }
}