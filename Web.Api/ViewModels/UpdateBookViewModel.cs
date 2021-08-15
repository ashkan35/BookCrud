using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.BookFeatures.BookMainFeatures.Commands;
using Application.Features.BookFeatures.BookMainFeatures.Commands.Update;
using Application.Profiles;
using FluentValidation;

namespace Web.Api.ViewModels
{
    public class UpdateBookViewModel:ICreateMapper<BookUpdateCommand>
    {
        public Guid Id { get; set; }
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
    public class UpdateBookViewModelValidator : AbstractValidator<UpdateBookViewModel>
    {
        public UpdateBookViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(2, 100);
            RuleFor(x => x.NumberOfPages).InclusiveBetween(5, 500);
            RuleFor(x => x.DateOfPublish).LessThan(DateTime.Now).WithMessage("تاریخ انتشار نمیتواند بیشتر از تاریخ امروز باشد");
        }
    }
}
