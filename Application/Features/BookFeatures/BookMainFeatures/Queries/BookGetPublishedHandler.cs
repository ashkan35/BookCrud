using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models.BookDtos;
using Application.Models.Common;
using AutoMapper;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Queries
{
    public class BookGetPublishedHandler:IRequestHandler<BookGetPublishedQuery,OperationResult<List<BookDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookGetPublishedHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<BookDto>>> Handle(BookGetPublishedQuery request, CancellationToken cancellationToken)
        {
            var result =await _unitOfWork.BookRepository.GetPublishedBooks();
            return OperationResult<List<BookDto>>.SuccessResult(_mapper.Map<List<BookDto>>(result));
        }
    }
}