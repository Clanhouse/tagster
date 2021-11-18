using System;
using System.Collections.Generic;
using Tagster.Application.Commands.AddTagsToProfile;
using Tagster.Application.Commands.GenFakeData;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Factories
{
    public class ProfileFactory
    {
        public static Profile Create(AddTagsToProfile request)
            => new() { Name = request.Name, LastName = request.Surname, ProfileTags = request.Tags , Href = request.Href};

        public static Profile Create(string surname, string name, ICollection<Tag> tags)
        {
            throw new NotImplementedException();
        }
    }
}
