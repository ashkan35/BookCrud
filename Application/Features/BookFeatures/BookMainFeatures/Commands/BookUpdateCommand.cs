using System;
using Application.Models.BookDtos;
using Application.Models.Common;
using Application.Profiles;
using Domain.Entities.BookEntities;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Commands
{
    public class BookUpdateCommand:IRequest<OperationResult<BookDto>>,ICreateMapper<Book>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        /// <example>436</example>
        public int NumberOfPages { get; set; }
        /// <example>ass123-125-262657RT</example>
        public string ShabekId { get; set; }
        ///<summary>نوبت چاپ</summary>
        /// <example>5</example>
        public string PublishOrderNumber { get; set; }
        /// <summary>تاریخ چاپ</summary>
        /// <example>2020-12-12</example>
        public DateTime DateOfPublish { get; set; }
        /// <summary>نام منتشر کننده</summary>
        /// <example>انتشارات پالیز</example>
        public string PublisherName { get; set; }

        /// <summary>
        /// آیدی کاربری که این کتاب را اضافه کرده است
        /// </summary>
        public int UserCreatedId { get; set; } = 1;
    }
}