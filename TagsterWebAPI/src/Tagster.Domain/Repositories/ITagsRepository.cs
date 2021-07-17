using System.Threading.Tasks;

namespace Tagster.Domain.Repositories
{
    public interface ITagsRepository
    {
        /// <summary>
        /// Get tag or tags
        /// </summary>
        /// <returns></returns>
        public Task<object> GetAsync();
        /// <summary>
        /// Add tag
        /// </summary>
        /// <returns></returns>
        public Task<bool> AddAsync();
        /// <summary>
        /// Update tag
        /// </summary>
        /// <returns></returns>
        public Task<bool> UpdateAsync();
        /// <summary>
        /// Delete tag
        /// </summary>
        /// <returns></returns>
        public Task<bool> DeleteAsync();

    }
}
