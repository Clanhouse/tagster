using FluentValidation;
namespace Tagster.DataAccess.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public int ProfileId { get; set; }
    }
    public class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("The Id cannot be NULL.");                
            RuleFor(x => x.TagName)
                .NotEmpty().WithMessage("The Tag cannot be blank.")
                .Length(0, 255).WithMessage("The Tag cannot be more than 255 characters");
            RuleFor(x => x.ProfileId)
                .NotNull().WithMessage("The ProfileId cannot be blank.");                
        }
    }
}