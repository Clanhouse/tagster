using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.DataAccess.Entities
{
    [Table("Profiles")]
    public record Profile(int Id, string Name, string LastName, ICollection<Tag> ProfileTags);
}