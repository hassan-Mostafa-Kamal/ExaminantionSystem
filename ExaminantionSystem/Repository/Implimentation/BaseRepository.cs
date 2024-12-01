
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository;
using Repository.Contract;
using System;
using System.Linq.Expressions;


namespace Repository.Implimentation
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseModel
    {
        private readonly StoreContext _context;
        private readonly DbSet<Entity> _dbSet;
        public BaseRepository(StoreContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }

        public async Task Add(Entity entity)
        {
           // entity.CreatedBy = user
           await _dbSet.AddAsync(entity);
      
        }




        public void SaveInclude(Entity entity, params string[] updatesProperties)
        {
            // 1:- chick if this object is traked by context or no 
            var searchForMyEntityLocally = _dbSet.Local.FirstOrDefault(x => x.Id == entity.Id);
            EntityEntry entry = null;
            if (searchForMyEntityLocally is null)
            {
                entry = _context.Entry(entity);
            }
            else
            {
                entry = _context.ChangeTracker.Entries<Entity>().FirstOrDefault(x => x.Entity.Id == entity.Id);
            }

            foreach (var property in entry.Properties)
            {
                if (!updatesProperties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;

                }
            }

        }

        public void SaveExeclude(Entity entity, params string[] unUpdatesProperties)
        {
            // 1:- chick if this object is traked by context or no 
            var searchForMyEntityLocally = _dbSet.Local.FirstOrDefault(x => x.Id == entity.Id);
            EntityEntry entry = null;
            if (searchForMyEntityLocally is null)
            {
                entry = _context.Entry(entity);
            }
            else
            {
                entry = _context.ChangeTracker.Entries<Entity>().FirstOrDefault(x => x.Entity.Id == entity.Id);
            }

            foreach (var property in entry.Properties)
            {
                if (unUpdatesProperties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;

                }
            }
        }




        public async Task SoftDelete(Entity entity)
        {
            entity.IsDeleted = true;
            //  await Update(entity);

            SaveInclude(entity, nameof(BaseModel.IsDeleted));
        }

        public IQueryable<Entity> Get(Expression<Func<Entity, bool>> Criatrie)
        {
           var entity =  GetAll().Where(Criatrie);
            return entity;
        }

        public async Task<Entity> GetById(int? id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public IQueryable<Entity> GetAll()
        {
         
            return _dbSet.Where(e=>e.IsDeleted == false);
            
        }

        public async Task Update(Entity entity)
        {
            _dbSet.Update(entity);
           
        }

        public IQueryable<Entity> GetAllWithIncludes(Func<IQueryable<Entity>, IQueryable<Entity>> includeExpression)
        {
            var query = _dbSet.Where(e=>!e.IsDeleted);
           
            if (includeExpression != null)
            {
                includeExpression(query);
            }
            return query;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}



//public interface IRepository<Entity>
//{
//    void Add(Entity entity);
//    void SaveInclude(Entity entity, params string[] properties);
//    void Delete(Entity entity);
//    IQueryable<Entity> GetAll();
//    IQueryable<Entity> GetAllWithDeleted();
//    public IQueryable<Entity> GetAllWithIncludes(Func<IQueryable<Entity>,IQueryable<Entity>> includeExpression);
//    Entity GetByID(int id);
//    bool IsFound(int id);
//    void SaveChanges();

//}



//public class Repository<Entity> : IRepository<Entity> where Entity : BaseModel
//    {
//        private readonly DbSet<Entity> _dbSet;

//        private readonly StoreContext _context;
//        public Repository(StoreContext context)
//        {
//            _context = context;
//            _dbSet = _context.Set<Entity>();
//        }
//        public void Add(Entity entity)
//        {
//           // entity.CreatedOn = DateTime.Now;
//            _dbSet.Add(entity);
//        }

//        public void Delete(Entity entity)
//        {
//            entity.IsDeleted = true;
//            SaveInclude(entity, nameof(BaseModel.IsDeleted));
//        }


//        public IQueryable<Entity> GetAll() => _dbSet.Where(e => !e.IsDeleted);
//        public IQueryable<Entity> GetAllWithIncludes(Func<IQueryable<Entity>, IQueryable<Entity>> includeExpression)
//        {
//            var set = _dbSet.Where(e => !e.IsDeleted);
//            return includeExpression(set);
//        }


//        public IQueryable<Entity> GetAllWithDeleted() => _dbSet;

//        public Entity GetByID(int id)
//        {
//            return GetAll().FirstOrDefault(e => e.Id == id);
//        }



//        public bool IsFound(int id)
//        {
//            return _dbSet.Any(e => e.Id == id);
//        }

//        public void SaveChanges()
//        {
//            _context.SaveChanges();
//        }

//        public void SaveInclude(Entity entity, params string[] properties)
//        {
//            var local = _dbSet.Local.FirstOrDefault(x => x.Id == entity.Id);

//            EntityEntry entry = null;

//            if (local is null)
//            {
//                entry = _dbSet.Entry(entity);
//            }
//            else
//            {
//                entry = _context.ChangeTracker.Entries<Entity>()
//                    .FirstOrDefault(x => x.Entity.Id == entity.Id);
//            }

//            foreach (var property in entry.Properties)
//            {
//                if (properties.Contains(property.Metadata.Name))
//                {
//                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
//                    property.IsModified = true;
//                }
//            }

//        }
//    }

