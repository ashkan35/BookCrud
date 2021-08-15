using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities.BookEntities
{
    public class Book:BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public string ShabekId { get; set; }
        public string PublishOrderNumber { get; set; }
        public DateTime DateOfPublish  { get; set; }
        //Its better to have an Entity and CRUD for publishers!
        public string PublisherName { get; set; }
        public bool IsPublished { get; set; }

        #region  Relations

        public User.User User { get; set; }
        public int UserCreatedId { get; set; }
        #endregion


    }
}
