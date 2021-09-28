using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.CQRS.Commands;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Commands.GenFakeData
{
    public class GenFakeData : ICommand
    {
        public int profilesCount { get; set; }
        public int maxTagsPerProfile { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
