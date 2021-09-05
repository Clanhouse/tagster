using System.ComponentModel.DataAnnotations.Schema;

namespace Tagster.DataAccess.Entities
{
    [Table("Tags")]
    public record Tag(int Id, string TagName, int ProfileId);
}