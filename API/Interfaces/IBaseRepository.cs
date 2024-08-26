using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public void Update(T entity);
        public Task<T> Add(T entity);
        public Task<bool> Delete(int id);
        public Task<bool> SaveAllAsync();
    }
}