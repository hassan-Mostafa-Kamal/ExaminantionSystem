using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contract
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task Add(T entity);

        Task Update(T entity);

        Task SoftDelete(T entity);

        IQueryable<T> GetAll();

        Task<T> Get(Expression<Func<T,bool>> Criatrie);
        Task<T> GetById(int? id);

        void SaveChanges();


    }
}
