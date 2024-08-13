using LinqToDB;
using SvaraKalkulators.Core.Data.DbAccess;
using SvaraKalkulators.Core.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SvaraKalkulators.Core.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDataConnection _conn;

        public GenericRepository(AppDataConnection conn)
        {
            _conn = conn;
        }

        public async Task<int> InsertAsync(T obj) =>
            await _conn
                .InsertWithInt32IdentityAsync(obj)
                .ConfigureAwait(false);

        public async Task UpdateAsync(T obj) =>
            await _conn
                .UpdateAsync(obj)
                .ConfigureAwait(false);

        public async Task DeleteAsync(T obj) =>
            await _conn
                .DeleteAsync(obj)
                .ConfigureAwait(false);
    }
}
