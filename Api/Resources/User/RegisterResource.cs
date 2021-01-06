using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Api.Resources.User
{
    public class RegisterResource
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        [Required]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,}", 
            ErrorMessage = "Enter a combination of at least six numbers, " +
            "letters punctuation marks(like ! and &).")]
        public string Password { get; set; }
    }

    public class RegisterResourceValidator : AbstractValidator<RegisterResource>
    {
        public RegisterResourceValidator()
        {
            RuleFor(m => m.Name).MaximumLength(50).NotNull();
            RuleFor(m => m.Surname).MaximumLength(50).NotNull();
            RuleFor(m => m.Email).EmailAddress().MaximumLength(50).NotNull();
            RuleFor(m => m.Password);
        }
    }
}