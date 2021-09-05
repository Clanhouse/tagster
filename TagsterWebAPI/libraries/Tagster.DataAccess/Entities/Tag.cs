using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.DataAccess.Entities
{
    [Table("Tags")]
    public record Tag {
        public int Id { get; set; }
        public string TagName { get; set; }
        public int ProfileId { get; set; }
    }
}