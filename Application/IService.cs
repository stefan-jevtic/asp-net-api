using System;
using System.Linq;
using System.Linq.Expressions;

namespace Application
{
    public interface IService<TEntity, TRes> where TEntity : class where TRes : class
    {
        int Insert(TEntity entity);
        void Update(TEntity entity, int id);
        void Delete(TEntity entity);
        void DeleteById(int id);
        TRes GetById(int id);
        IQueryable<TRes> GetAll();
    }
}