using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Contracts.Identity;
using Application.Contracts.Services;
using Application.Models.Common;
using MediatR;

namespace Application.Features.Users.Queries.TokenRequest
{
   public class UserTokenRequestQueryHandler:IRequestHandler<UserTokenRequestQuery,OperationResult<UserTokenRequestQueryResult>>
   {
       private readonly IAppUserManager _userManager;
       private readonly IMediator _mediator;
       private readonly ISmsService _smsService;

       public UserTokenRequestQueryHandler(IAppUserManager userManager, IMediator mediator,ISmsService smsService)
       {
           _userManager = userManager;
           _mediator = mediator;
           _smsService = smsService;
       }


        public async Task<OperationResult<UserTokenRequestQueryResult>> Handle(UserTokenRequestQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserByPhoneNumber(request.UserPhoneNumber);

            if(user is null)
                return OperationResult<UserTokenRequestQueryResult>.NotFoundResult("کاربر یافت نشد");

            var code = await _userManager.GeneratePhoneNumberToken(user, user.PhoneNumber);

            await _smsService.SendVerificationCode(user.PhoneNumber, code);

            return OperationResult<UserTokenRequestQueryResult>.SuccessResult(new UserTokenRequestQueryResult{UserKey = user.GeneratedCode});
        }
    }
}
