using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Common;
using E_Commerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T, int> where T : BaseModel
    {
        private readonly ECommerceDbContext dbContext;

        public GenericRepository(ECommerceDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<T> Create(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var dbEntity = await dbContext.Set<T>().Where(i => i.Id == id).FirstOrDefaultAsync();

            if (dbEntity == null)
                throw new Exception("Not found");

            dbContext.Set<T>().Remove(dbEntity);
            int result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbContext.Set<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> Update(T entity)
        {
            var dbEntity = await dbContext.Set<T>().Where(i => i.Id == entity.Id).FirstOrDefaultAsync();

            if (dbEntity == null)
                throw new Exception("Not found");

            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            return dbEntity;
        }
    }
}
