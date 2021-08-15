using Application.Models.Common;
using FluentValidation;
using MediatR;
using Utils;

namespace Application.Features.Users.Commands.Create
{
   public class UserCreateCommand : IRequest<OperationResult<UserCreateCommandResult>>
   {
       ///<summary>کد ملی</summary>
       /// <example>Ali354</example>
        public string UserName { get; set; }
       /// <example>علی</example>
        public string FirstName { get; set; }
       /// <example>علی زاده</example>
        public string LastName { get; set; }
       /// <example>09121111111</example>
        public string PhoneNumber { get; set; }

       public string Password { get; set; }
       public string RetypePassword { get; set; }
   }

   public class UserCreateCommandValidator : AbstractValidator<UserCreateCommand>
   {
       public UserCreateCommandValidator()
       {

           RuleFor(x => x.PhoneNumber).NotNull();
           RuleFor(x => x.PhoneNumber).Must(x => x.IsPhoneNumber()).WithMessage("شماره تلفن همراه معتبر نیست");
       }
   }

}
