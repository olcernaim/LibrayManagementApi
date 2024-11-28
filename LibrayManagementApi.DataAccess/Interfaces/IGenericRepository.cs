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
        void Add(T objModel);
        void AddRange(IEnumerable<T> objModel);
        T? GetId(int id);
        Task<T?> GetIdAsync(int id);
        T? Get(Expression<Func<T, bool>> predicate);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        int Count();
        Task<int> CountAsync();
        void Update(T objModel);
        void Remove(T objModel);
        void Dispose();
    }
}
