using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T: BaseEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> entities;

        public BaseRepo(DataContext context) {
            _context = context;
            entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await entities.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entityToDelete = await GetAsync(id);
            if (entityToDelete != null)
            {
                entities.Remove(entityToDelete);
                await _context.SaveChangesAsync();
            }
            return entityToDelete;
        }
    }
}
