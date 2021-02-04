using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Resources.User
{
    public class UpdateProfileResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UpdateDate { get; set; }
    }

    public class UpdateProfileResourceValidator : AbstractValidator<UpdateProfileResource>
    {
        public UpdateProfileResourceValidator()
        {
            RuleFor(m => m.Name).MaximumLength(50);
            RuleFor(m => m.Surname).MaximumLength(50);
            RuleFor(m => m.Email).EmailAddress().MaximumLength(50);
        }
    }
}
