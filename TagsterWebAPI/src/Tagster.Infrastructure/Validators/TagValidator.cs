using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Tagster.Domain.Entities;

namespace Tagster.Infrastructure.Validators;

internal class TagValidator :  AbstractValidator<Tag>
{
    public TagValidator()
    {
        //Name
        RuleFor(m => m.Name).NotEmpty();
        RuleFor(m => m.Name).NotNull();
        RuleFor(m => m.Name).MaximumLength(255);
        //ProfileID
        RuleFor(m => m.ProfileId).NotNull();
        //ID
        RuleFor(m => m.Id).NotNull();
    }
}
