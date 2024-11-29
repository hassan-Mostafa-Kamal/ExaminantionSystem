using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contract
{
    public interface IBaseRepository<Entity> where Entity : BaseModel
    {
        Task Add(Entity entity);

        Task Update(Entity entity);
        void SaveInclude(Entity entity,params string[] updatesProperties);
        void SaveExeclude(Entity entity,params string[] unUpdatesProperties);

        Task SoftDelete(Entity entity);

        IQueryable<Entity> GetAll();

        IQueryable<Entity> GetAllWithIncludes(Func<IQueryable<Entity>,IQueryable<Entity>> includeExpression);

        IQueryable<Entity> Get(Expression<Func<Entity,bool>> Criatrie);
        Task<Entity> GetById(int? id);

        void SaveChanges();


    }
}
