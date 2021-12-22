using FluentValidation;
using TestZigzagApi.Models.Validators.Constants;

namespace TestZigzagApi.Models.Validators
{
    public class LoginRegisterRequestValidator : AbstractValidator<LoginRegisterRequest>
    {
        public LoginRegisterRequestValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(LoginRegisterValidationConstants.MaximumPasswordLength);
            
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(LoginRegisterValidationConstants.MaximumUserNameLength);
        }
    }
}