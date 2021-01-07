using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Resources.Category
{
    public class UpdateCategoryResource
    {
        public string Name { get; set; }
    }

    public class UpdateCategoryResourceValidator : AbstractValidator<UpdateCategoryResource>
    {
        public UpdateCategoryResourceValidator()
        {
            RuleFor(m => m.Name).MaximumLength(50).NotNull();
        }
    }
}
