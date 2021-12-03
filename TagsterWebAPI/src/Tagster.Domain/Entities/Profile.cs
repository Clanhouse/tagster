using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.Domain.Entities;

[Table("Profiles")]
public record Profile
{
    [Key]
    public int Id { get; set; }
    public string Href { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public ICollection<Tag> Tags { get; set; }
}
