using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.DataAccess.DBContexts;
using Tagster.Domain.Repositories;

namespace Tagster.Infrastructure.Repositories
{
    internal sealed class TagsRepository : ITagsRepository
    {
        private readonly ITagsterDbContext _tagsterDb;

        public TagsRepository(ITagsterDbContext tagsterDb)
            => _tagsterDb = tagsterDb;

        public Task<bool> AddAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
