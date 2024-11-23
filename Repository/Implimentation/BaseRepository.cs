
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using System.Linq.Expressions;


namespace Repository.Implimentation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly StoreContext _context;

        public BaseRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
           // entity.CreatedBy = user
           await _context.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            await Update(entity);

        }

        public async Task<T> Get(Expression<Func<T, bool>> Criatrie)
        {
           var entity = await   _context.Set<T>().FirstOrDefaultAsync(Criatrie);
            return entity;
        }

        public async Task<T> GetById(int? id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
          return    _context.Set<T>().Where(e=>e.IsDeleted == false);
            
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
