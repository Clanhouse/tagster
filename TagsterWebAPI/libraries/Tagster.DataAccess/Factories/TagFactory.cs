using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.Factories
{
    internal static class TagFactory
    {
        public static IEnumerable<Tag> Create() 
        {

            return new List<Tag>();
        }
    }
}
