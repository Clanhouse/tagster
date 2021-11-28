using System;
using System.Collections.Generic;
using Tagster.Application.Commands.AddTagsToProfile;
using Tagster.Domain.Entities;

namespace Tagster.Application.Factories
{
    public class ProfileFactory
    {
        public static Profile Create(AddTagsToProfile request)
            => new() { Name = request.Name, LastName = request.Surname, Tags = request.Tags, Href = request.Href };

        public static Profile Create(string surname, string name, ICollection<Tag> tags)
        {
            throw new NotImplementedException();
        }
    }
}
