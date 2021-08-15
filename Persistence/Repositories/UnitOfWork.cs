using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.BookContracts;
using Application.Contracts.Persistence;
using Persistence.Repositories.BookRepo;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
       
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        public IBookRepository BookRepository { get; }
        public UnitOfWork(ApplicationDbContext db)
       {
           _db = db;
           UserRefreshTokenRepository = new UserRefreshTokenRepository(_db);
           BookRepository = new BookRepository(_db);
       }

        public  Task CommitAsync()
        {
            return _db.SaveChangesAsync();
        }

        public ValueTask RollBackAsync()
        {
            return _db.DisposeAsync();
        }
   }
}
