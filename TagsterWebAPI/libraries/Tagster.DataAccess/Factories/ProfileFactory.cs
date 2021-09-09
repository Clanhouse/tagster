using System.Collections.Generic;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.Factories
{
    public class ProfileFactory
    {
        public static Profile Create(int id, string surname, string name, ICollection<Tag> tags)
                => new() { Id = id, LastName = surname, Name = name, ProfileTags = tags };

    }
}
