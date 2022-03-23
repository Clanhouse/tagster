using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Tagster.Application.Commands.AddTagsToProfile;

namespace Tagster.Infrastructure.Validators;

internal class AddTagsToProfileValidator : AbstractValidator<AddTagsToProfile>
{
    public AddTagsToProfileValidator()
    {
        //Name
        RuleFor(m => m.Name).NotEmpty();
        RuleFor(m => m.Name).NotNull();
        RuleFor(m => m.Name).MaximumLength(255);
        //Surname
        RuleFor(m => m.Surname).NotEmpty();
        RuleFor(m => m.Surname).NotNull();
        RuleFor(m => m.Surname).MaximumLength(255);
        //Tags collection
        RuleFor(m => m.Tags).NotEmpty();
        RuleFor(m => m.Tags).NotNull();
        

    }
}
