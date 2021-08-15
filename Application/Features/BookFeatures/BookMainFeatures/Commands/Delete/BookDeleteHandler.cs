using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models.Common;
using MediatR;

namespace Application.Features.BookFeatures.BookMainFeatures.Commands.Delete
{
    public class BookDeleteHandler:IRequestHandler<BookDeleteCommand,OperationResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookDeleteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<bool>> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
        {
            var book =await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            if (book == null)
                return OperationResult<bool>.NotFoundResult("کتاب مورد نظر وجود ندارد");
            await _unitOfWork.BookRepository.DeleteAsync(book);
            await _unitOfWork.CommitAsync();
            return OperationResult<bool>.SuccessResult(true);
        }
    }
}