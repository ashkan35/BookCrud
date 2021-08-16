using System;
using Application.Profiles;
using Domain.Entities.BookEntities;
using FluentValidation;

namespace Application.Models.BookDtos
{
    public class BookDto:ICreateMapper<Book>
    {
        public Guid Id { get; set; }
        /// <example>کد نویسی تمیز با جعفر نژاد قمی!</example>
        public string Name { get; set; }
        /// <example>436</example>
        public int NumberOfPages { get; set; }
        /// <example>ass123-125-262657RT</example>
        public string ShabekId { get; set; }
        ///<summary>نوبت چاپ</summary>
        /// <example>5</example>
        public string PublishOrder { get; set; }
        /// <summary>تاریخ چاپ</summary>
        /// <example>2020-12-12</example>
        public DateTime DateOfPublish { get; set; }
        /// <summary>نام منتشر کننده</summary>
        /// <example>انتشارات پالیز</example>
        public string PublisherName { get; set; }

        /// <summary>
        /// آیدی کاربری که این کتاب را اضافه کرده است
        /// </summary>
        public int UserCreatedId { get; set; }

        public bool IsPublished { get; set; }

    }

    public class BookDtoValidator : AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(2, 100);
            RuleFor(x => x.NumberOfPages).InclusiveBetween(5, 500);
        }
    }
}