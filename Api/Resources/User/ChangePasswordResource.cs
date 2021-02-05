using FluentValidation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api.Resources.User
{
    public class ChangePasswordResource
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,}",
             ErrorMessage = "Enter a combination of at least six numbers, " +
             "letters.")]
        public string OldPassword { get; set; }
        [Required]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,}",
             ErrorMessage = "Enter a combination of at least six numbers, " +
             "letters.")]
        public string NewPassword { get; set; }
    }

    public class ChangePasswordResourceValidator : AbstractValidator<ChangePasswordResource>
    {
        public ChangePasswordResourceValidator()
        {
            RuleFor(m => m.OldPassword);
            RuleFor(m => m.NewPassword);
            RuleFor(m => m.Email).EmailAddress().MaximumLength(50).NotNull();
        }
    }
}
