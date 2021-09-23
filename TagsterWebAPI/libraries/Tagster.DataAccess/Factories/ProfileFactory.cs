using System.Collections.Generic;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.Factories
{
    public class ProfileFactory
    {
        public static Profile Create(string surname, string name, ICollection<Tag> tags)
                => new() { LastName = surname, Name = name, ProfileTags = tags };

    }
}
