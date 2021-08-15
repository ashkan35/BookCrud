using System;
using Application.Models.Common;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Commands.Delete
{
    public class BookDeleteCommand:IRequest<OperationResult<bool>>
    {
        public Guid BookId { get; set; }
    }
}