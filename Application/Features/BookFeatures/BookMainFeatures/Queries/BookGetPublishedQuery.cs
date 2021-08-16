using System.Collections.Generic;
using Application.Models.BookDtos;
using Application.Models.Common;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Queries
{
    public class BookGetPublishedQuery:IRequest<OperationResult<List<BookDto>>>
    {
        
    }
}