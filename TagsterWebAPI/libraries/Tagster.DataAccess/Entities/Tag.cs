using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.DataAccess.Entities
{
    [Table("Tags")]
    public record Tag
    {
        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
        public int ProfileId { get; set; }
    }
}