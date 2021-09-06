<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations.Schema;
=======
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7

namespace Tagster.DataAccess.Entities
{
    [Table("Tags")]
<<<<<<< HEAD
    public record Tag {
=======
    public record Tag
    {
        [Key]
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        public int Id { get; set; }
        public string TagName { get; set; }
        public int ProfileId { get; set; }
    }
}