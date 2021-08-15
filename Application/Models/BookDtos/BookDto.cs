using System;
using FluentValidation;

namespace Application.Models.BookDtos
{
    public class BookDto
    {
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public string ShabekId { get; set; }
        public string PublishOrderNumber { get; set; }
        public DateTime DateOfPublish { get; set; }
        public string PublisherName { get; set; }
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