using System.Collections.Generic;

namespace Tagster.Application.Dtos
{
    public record ProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Href { get; set; }
        public ICollection<TagDto> Tags { get; set; }
    }
}
