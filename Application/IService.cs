using System;
using System.Linq;
using System.Linq.Expressions;

namespace Application
{
    public interface IService<TEntity> where TEntity : class
    {
        int Insert(TEntity entity);
        void Update(TEntity entity, int id);
        void Delete(TEntity entity);
        void DeleteById(int id);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
    }
}