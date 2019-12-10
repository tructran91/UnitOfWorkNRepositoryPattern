using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWorkNRepositoryPattern.Repos.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(int id);
    }
}
