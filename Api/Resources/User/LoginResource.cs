using FluentValidation;

namespace Api.Resources.User
{
    public class LoginResource
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResourceValidator : AbstractValidator<LoginResource>
    {
        public LoginResourceValidator()
        {
            RuleFor(m => m.Email).EmailAddress().MaximumLength(50).NotNull();
            RuleFor(m => m.Password).MinimumLength(6).MaximumLength(100).NotNull();
        }
    }
}
