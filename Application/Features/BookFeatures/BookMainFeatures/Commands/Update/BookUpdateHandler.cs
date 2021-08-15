using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models.BookDtos;
using Application.Models.Common;
using AutoMapper;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Commands.Update
{
    public class BookUpdateHandler:IRequestHandler<BookUpdateCommand,OperationResult<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookUpdateHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OperationResult<BookDto>> Handle(BookUpdateCommand request, CancellationToken cancellationToken)
        {
            var book =await _unitOfWork.BookRepository.GetBookByIdAsync(request.Id);
            if (book == null)
                return OperationResult<BookDto>.NotFoundResult("کتاب مورد نظر وجود ندارد");
            else
            {
                try
                {
                    _mapper.Map(request, book);
                    await _unitOfWork.BookRepository.UpdateAsync(book);
                    await _unitOfWork.CommitAsync();
                    return OperationResult<BookDto>.SuccessResult(_mapper.Map<BookDto>(book));
                }
                catch (Exception )
                {
                    return  OperationResult<BookDto>.FailureResult("مشکلی در ذخیره داده بوجود آمده است لطفا مجددا تلاش فرمائید");
                }
            }

        }
    }
}