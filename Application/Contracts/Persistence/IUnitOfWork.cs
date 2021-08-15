using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.BookContracts;

namespace Application.Contracts.Persistence
{
   public interface IUnitOfWork
   {
       public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
       public IBookRepository BookRepository { get;}
       Task CommitAsync();
       ValueTask RollBackAsync();
   }
}
