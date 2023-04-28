

using Wolt.Core.Models.Base;

namespace Wolt.Core.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        public Task AddAsync(T model);

        public Task<T> GetAsync(Func<T, bool> expression);

        public Task<List<T>> GetAllAsync();

        public Task RemoveAsync(T model);
    }
}
