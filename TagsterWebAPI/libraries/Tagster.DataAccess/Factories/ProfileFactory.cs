using System.Collections.Generic;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.Factories
{
    public class ProfileFactory
    {
        public static Profile Create(string name, string surname, ICollection<Tag> tags)
                => new() { Name = name, LastName = surname, ProfileTags = tags };

    }
}
