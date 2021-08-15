using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Models.Common;
using Domain.Entities.User;
using MediatR;

namespace Application.Features.Users.Commands.Create
{
    public class UserCreateHandler : IRequestHandler<UserCreateCommand, OperationResult<UserCreateCommandResult>>
    {

        private readonly IAppUserManager _userManager;
        private readonly IMediator _mediator;
        private readonly ISmsService _smsService;

        public UserCreateHandler(IAppUserManager userManager, IMediator mediator,ISmsService smsService)
        {
            _userManager = userManager;
            _mediator = mediator;
            _smsService = smsService;
        }

        public async Task<OperationResult<UserCreateCommandResult>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var userNameExist = await _userManager.IsExistUser(request.PhoneNumber);

            if (userNameExist)
                return OperationResult<UserCreateCommandResult>.FailureResult("این شماره تلفن وجود دارد");

            var phoneNumberExist = await _userManager.IsExistUserName(request.UserName);

            if (phoneNumberExist)
                return OperationResult<UserCreateCommandResult>.FailureResult("این نام کاربری وجود دارد");

            var user = new User { UserName = request.UserName, Name = request.FirstName, FamilyName = request.LastName, PhoneNumber = request.PhoneNumber, PhoneNumberConfirmed = true };

            var createResult = await _userManager.CreateUserWithPassword(user,request.Password);

            if (!createResult.Succeeded)
            {
                return OperationResult<UserCreateCommandResult>.FailureResult(string.Join(",", createResult.Errors.Select(c => c.Description)));
            }

            var code = await _userManager.GeneratePhoneNumberToken(user, user.PhoneNumber);

            await _smsService.SendVerificationCode(user.PhoneNumber, code);

            return OperationResult<UserCreateCommandResult>.SuccessResult(new UserCreateCommandResult { UserGeneratedKey = user.GeneratedCode });
        }
    }
}
