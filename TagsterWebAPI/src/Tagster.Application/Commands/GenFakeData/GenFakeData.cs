using Tagster.CQRS.Commands;

namespace Tagster.Application.Commands.GenFakeData;

public class GenFakeData : ICommand
{
    public int ProfilesCount { get; set; } = 10;
    public int MaxTagsPerProfile { get; set; } = 20;
}
