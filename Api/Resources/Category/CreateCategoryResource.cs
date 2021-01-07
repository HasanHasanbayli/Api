using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Api.Resources.Category
{
    public class CreateCategoryResource
    {
        [Required]
        public string Name { get; set; }
    }

    public class CreateCategoryResourceValidator : AbstractValidator<CreateCategoryResource>
    {
        public CreateCategoryResourceValidator()
        {
            RuleFor(m => m.Name).MaximumLength(50).NotNull();
        }
    }
}