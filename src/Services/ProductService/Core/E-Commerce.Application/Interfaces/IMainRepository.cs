using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Interfaces
{
    public interface IMainRepository<T, TKey>
        where TKey : IEquatable<TKey>
    {
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<List<T>> GetAll();
        public Task<bool> Delete(TKey id);
        public Task<T> GetById(TKey id);
    }
}
