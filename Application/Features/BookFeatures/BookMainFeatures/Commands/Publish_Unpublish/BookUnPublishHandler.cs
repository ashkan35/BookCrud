using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models.Common;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Commands.Publish_Unpublish
{
    public class BookUnPublishHandler:IRequestHandler<BookUnPublishCommand,OperationResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookUnPublishHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<bool>> Handle(BookUnPublishCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            if (book == null)
                return OperationResult<bool>.NotFoundResult("کتاب مورد نظر وجود ندارد");
            

            //ToDo:check some conditions or call BookService unPublish method
            var unPublishResult = true;
            if (unPublishResult)
            {
                book.IsPublished = false;
                await _unitOfWork.BookRepository.UpdateAsync(book);
                await _unitOfWork.CommitAsync();
                return OperationResult<bool>.SuccessResult(true);
            }
            return OperationResult<bool>.FailureResult("انتشار کتاب مورد نظر در حال حاضر امکان پذیر نمیباشد");
        }
    }
}