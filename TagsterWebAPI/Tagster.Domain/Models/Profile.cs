using System.Collections.Generic;

namespace Tagster.Domain.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Tag> ProfileTags { get; set; } = new List<Tag>();
    }
}