using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkNRepositoryPattern.Data.Models;

namespace UnitOfWorkNRepositoryPattern.Repos.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<T> Repository<T>() where T : class;
        void Commit();
    }
}
