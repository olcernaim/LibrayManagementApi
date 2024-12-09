using LibrayManagementApi.Data;
using LibrayManagementApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementApi.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private LibManagementContext _context = null;
        private DbSet<T> table = null;
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public GenericRepository(LibManagementContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public bool Insert(T obj)
        {
            table.Add(obj);
            var result = _context.SaveChanges();

            if (result > 0)
                return true;
            else
                return false;
        }
        public bool Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;

            var result = _context.SaveChanges();

            if (result > 0)
                return true;
            else
                return false;
        }
        public bool Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);

            var result = _context.SaveChanges();

            if (result > 0)
                return true;
            else
                return false;
        }

        public bool InsertMany(List<T> obj)
        {
            table.AddRange(obj);
            var result = _context.SaveChanges();

            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> InsertManyAsync(List<T> obj)
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                table.AddRangeAsync(obj);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                //When the task is ready, release the semaphore. It is vital to ALWAYS release the semaphore when we are ready, or else we will end up with a Semaphore that is forever locked.
                //This is why it is important to do the Release within a try...finally clause; program execution may crash or take a different path, this way you are guaranteed execution
                semaphoreSlim.Release();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

        public async Task<T> InsertAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<T> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

        public async Task<T> UpdateAsync(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<int> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            //_context.Entry(entities).State = EntityState.Modified;
            await _context.AddRangeAsync(entities, cancellationToken);
            try
            {
                var numAdded = await _context.SaveChangesAsync();

                return numAdded;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public virtual async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);

            var numAdded = await _context.SaveChangesAsync();

            return numAdded;
        }

        public void DeleteAll()
        {
            table.RemoveRange(table);
            _context.SaveChanges();
        }
    }
}
