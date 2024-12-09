using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementApi.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        bool Insert(T obj);
        bool Update(T obj);
        bool Delete(object id);
        bool InsertMany(List<T> objList);
        void DeleteAll();
        Task<bool> InsertManyAsync(List<T> obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<int> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<int> DeleteRangeAsync(IEnumerable<T> entities);
    }
}
