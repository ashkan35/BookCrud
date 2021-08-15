using System;
using System.Threading.Tasks;
using Application.Contracts.BookContracts;
using Domain.Entities.BookEntities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.BookRepo
{
    public class BookRepository:BaseAsyncRepository<Book>,IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public  Task<Book> GetBookByIdAsync(Guid bookId)
        {
            return   Entities.SingleOrDefaultAsync(x => x.Id == bookId);
        }
    }
}