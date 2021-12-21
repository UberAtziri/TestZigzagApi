using FluentValidation;

namespace TestZigzagApi.Models.Validators
{
    public class LoginRegisterRequestValidator : AbstractValidator<LoginRegisterRequest>
    {
        public LoginRegisterRequestValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            
            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
        }
    }
}