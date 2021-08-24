using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.Factories
{
    internal static class ProfileFactory
    {
        public static Profile Create()
        {
            return new Profile();
        }
    }
}
