using System;
using Domain.Common;
using Domain.Entities.AuthorEntities;

namespace Domain.Entities.BookEntities
{
    public class BookAuthor:IEntity
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }

        #region Relations

        public Book Book { get; set; }
        public Author Author { get; set; }

        #endregion
    }
}