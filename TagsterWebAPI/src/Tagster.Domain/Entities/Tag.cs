using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.Domain.Entities
{
    [Table("Tags")]
    public record Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfileId { get; set; }
    }
}
