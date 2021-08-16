using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities.BookEntities;

namespace Application.Contracts.BookContracts
{
    public interface IBookRepository:IAsyncRepository<Book>
    {
        Task<Book> GetBookByIdAsync(Guid bookId);
        Task<List<Book>> GetPublishedBooks();
        Task<Book> GetPublishedBookById(Guid bookId);
    }
}