﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.User;

namespace Application.Contracts.Persistence
{
   public interface IUserRefreshTokenRepository
    {
        Task<Guid> CreateToken(int userId);
        Task<UserRefreshToken> GetTokenWithInvalidation(Guid id);
        Task<User> GetUserByRefreshToken(Guid tokenId);
        Task RemoveUserOldTokens(int userId, CancellationToken cancellationToken);
    }
}