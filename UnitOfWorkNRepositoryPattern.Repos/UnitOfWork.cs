using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkNRepositoryPattern.Data.Models;
using UnitOfWorkNRepositoryPattern.Repos.Contracts;

namespace UnitOfWorkNRepositoryPattern.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDBContext _dbContext;
        public MovieGenericRepository MovieGenericRepository { get; set; }

        public UnitOfWork(MovieDBContext context)
        {
            _dbContext = context;
            MovieGenericRepository = new MovieGenericRepository(_dbContext);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
