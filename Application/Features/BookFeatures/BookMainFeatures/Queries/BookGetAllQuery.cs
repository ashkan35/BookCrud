using System.Collections.Generic;
using Application.Models.BookDtos;
using Application.Models.Common;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Queries
{
    public class BookGetAllQuery:IRequest<OperationResult<List<BookDto>>>
    {
        
    }
}