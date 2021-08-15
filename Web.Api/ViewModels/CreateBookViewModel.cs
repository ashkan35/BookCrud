using System;
using Application.Features.BookFeatures.BookMainFeatures.Commands;
using Application.Features.BookFeatures.BookMainFeatures.Commands.Create;
using Application.Profiles;
using FluentValidation;

namespace Web.Api.ViewModels
{
    public class CreateBookViewModel: ICreateMapper<BookCreateCommand>
    {
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

       
    }

    public class CreateBookViewModelValidator : AbstractValidator<CreateBookViewModel>
    {
        public CreateBookViewModelValidator()
        {
             RuleFor(x => x.Name).NotNull().Length(2, 100);
            RuleFor(x => x.NumberOfPages).InclusiveBetween(5, 500);
            RuleFor(x => x.NumberOfPages).InclusiveBetween(5, 500);
            RuleFor(x=>x.DateOfPublish).LessThan(DateTime.Now).WithMessage("تاریخ انتشار نمیتواند بیشتر از تاریخ امروز باشد");
        }
    }
}