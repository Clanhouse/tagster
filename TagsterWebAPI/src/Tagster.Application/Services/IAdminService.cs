using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagster.Application.Services
{
    public interface IAdminService
    {
        public Task CreateFakeDataAsync(int profilesCount, int maxTagsPerProfile);
    }
}
