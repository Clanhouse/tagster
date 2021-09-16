using System.Collections.Generic;
using FluentValidation;

namespace Tagster.DataAccess.Entities
{  
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Href { get; set; }
        public ICollection<Tag> ProfileTags { get; set; } = new List<Tag>();
    }

    public class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.ProfileId)
                .NotNull().WithMessage("The ProfileId cannot be blank.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The Name cannot be blank.")
                .Length(0, 255).WithMessage("The Name cannot be more than 255 characters");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("The LastName cannot be blank.")
                .Length(0, 255).WithMessage("The LastName cannot be more than 255 characters");
            RuleFor(x => x.Href)
                .NotEmpty().WithMessage("The Href cannot be blank.")
                .Length(0, 255).WithMessage("The Href cannot be more than 255 characters");
        }
            
    }    
}