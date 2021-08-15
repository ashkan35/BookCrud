using Application.Contracts.BookContracts;
using Domain.Entities.BookEntities;

namespace Persistence.Repositories.BookRepo
{
    public class BookRepository:BaseAsyncRepository<Book>,IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}