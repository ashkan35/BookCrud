using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models.Common;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Commands.Publish_Unpublish
{
    public class BookPublishHandler:IRequestHandler<BookPublishCommand,OperationResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookPublishHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async  Task<OperationResult<bool>> Handle(BookPublishCommand request, CancellationToken cancellationToken)
        {
            var book =await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            if(book==null)
                return OperationResult<bool>.NotFoundResult("کتاب مورد نظر وجود ندارد");
           
            
            //ToDo:check some conditions or call BookService publish method
            var publishResult = true;
            if (publishResult)
            {
                book.IsPublished = true;
                await _unitOfWork.BookRepository.UpdateAsync(book);
                await _unitOfWork.CommitAsync();
                return OperationResult<bool>.SuccessResult(true);
            }
            return OperationResult<bool>.FailureResult("انتشار کتاب مورد نظر در حال حضر امکان پذیر نمیباشد");
        }
    }
}