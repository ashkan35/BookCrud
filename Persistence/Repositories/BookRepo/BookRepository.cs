using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<Book>> GetPublishedBooks()
        {
            return Entities.Where(x => x.IsPublished).ToListAsync();
        }

        public Task<Book> GetPublishedBookById(Guid bookId)
        {
            return Entities.SingleOrDefaultAsync(x => x.Id == bookId&&x.IsPublished);
        }
    }
}