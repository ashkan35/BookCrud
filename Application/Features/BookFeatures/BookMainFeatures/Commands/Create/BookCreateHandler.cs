using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models.BookDtos;
using Application.Models.Common;
using AutoMapper;
using Domain.Entities.BookEntities;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Commands.Create
{
    public class BookCreateHandler:IRequestHandler<BookCreateCommand,OperationResult<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookCreateHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OperationResult<BookDto>> Handle(BookCreateCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            try
            {
                await _unitOfWork.BookRepository.AddAsync(book);
                await _unitOfWork.CommitAsync();
                return OperationResult<BookDto>.SuccessResult(_mapper.Map<BookDto>(book));
            }
            catch (Exception e)
            {
                return OperationResult<BookDto>.FailureResult("مشکل در ذخیره داده در دیتابیس");
            }
        }
    }
}