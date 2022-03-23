using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Tagster.Application.Commands.SignIn;

namespace Tagster.Infrastructure.Validators;

internal class SignInValidator : AbstractValidator<SignIn>
{
    public SignInValidator()
    {
        //Email
        RuleFor(m => m.Email).NotEmpty();
        RuleFor(m => m.Email).EmailAddress();
        //Password
        RuleFor(m => m.Password).NotEmpty();
    }
}
