namespace Tagster.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public int ProfileId { get; set; }
    }
}