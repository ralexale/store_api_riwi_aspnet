using FluentValidation;
using store_api_riwi.src.Api.DTOs.Request;

namespace store_api_riwi.src.Api.Validators.Request
{
    public class UserValidatorRequest: AbstractValidator<UserRequest>
    {
        public UserValidatorRequest() {

            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Name).Length(2, 32);

            RuleFor(u => u.Lastname).Length(2, 32);
            RuleFor(u => u.Lastname).NotEmpty();

            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Email).NotEmpty();

        }
    }
}
