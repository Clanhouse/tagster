using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.Factories
{
    public class ProfileFactory
    {
        public static Profile Create(int id, string surname, string name, ICollection<Tag> tags)
        {
            var profile = new Profile
            {
                Id = id,
                LastName = surname,
                Name = name,
                ProfileTags = tags
            };

            return profile;
        }
    }
}
