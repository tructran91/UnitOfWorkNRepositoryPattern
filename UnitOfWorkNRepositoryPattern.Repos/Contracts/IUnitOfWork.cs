using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkNRepositoryPattern.Repos.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
