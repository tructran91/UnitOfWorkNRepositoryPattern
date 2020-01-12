using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkNRepositoryPattern.Data.Models;

namespace UnitOfWorkNRepositoryPattern.Repos.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Movie> MovieRepository { get; }
        public IGenericRepository<Director> DirectorRepository { get; }
        public IGenericRepository<Genre> GenreRepository { get; }
        void Commit();
    }
}
