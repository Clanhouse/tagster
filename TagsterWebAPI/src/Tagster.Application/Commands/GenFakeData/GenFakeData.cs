using System.Collections.Generic;
using Tagster.CQRS.Commands;
using Tagster.Domain.Entities;

namespace Tagster.Application.Commands.GenFakeData;

public class GenFakeData : ICommand
{
    public int ProfilesCount { get; set; }
    public int MaxTagsPerProfile { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Tag> Tags { get; set; }
}
