using System.Collections.Generic;
using Tagster.CQRS.Commands;
using Tagster.Domain.Entities;

namespace Tagster.Application.Commands.AddTagsToProfile;

public class AddTagsToProfile : ICommand
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Href { get; set; }
    public ICollection<Tag> Tags { get; set; }
}
