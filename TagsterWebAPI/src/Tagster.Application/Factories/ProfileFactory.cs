using Tagster.Application.Commands.AddTagsToProfile;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Factories
{
    public class ProfileFactory
    {
        public static Profile Create(AddTagsToProfile request)
                => new() { Name = request.Name, LastName = request.Surname, ProfileTags = request.Tags };

    }
}
