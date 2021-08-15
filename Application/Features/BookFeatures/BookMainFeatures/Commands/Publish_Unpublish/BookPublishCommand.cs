using System;
using Application.Models.Common;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Commands.Publish_Unpublish
{
    public class BookPublishCommand:IRequest<OperationResult<bool>>
    {
        public Guid BookId { get; set; }

    }
}