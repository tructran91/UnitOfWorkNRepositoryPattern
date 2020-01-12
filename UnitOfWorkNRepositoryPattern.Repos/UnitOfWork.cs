using System;
using UnitOfWorkNRepositoryPattern.Data.Models;
using UnitOfWorkNRepositoryPattern.Repos.Contracts;

namespace UnitOfWorkNRepositoryPattern.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieDBContext _context;
        private IGenericRepository<Movie> _movieRepository;
        private IGenericRepository<Director> _directorRepository;
        private IGenericRepository<Genre> _genreRepository;
        private string _errorMessage = string.Empty;

        public UnitOfWork(MovieDBContext context)
        {
            _context = context;
        }

        public IGenericRepository<Movie> MovieRepository
        {
            get
            {
                return _movieRepository ?? (_movieRepository = new GenericRepository<Movie>(_context));
            }
        }

        public IGenericRepository<Director> DirectorRepository
        {
            get
            {
                return _directorRepository ?? (_directorRepository = new GenericRepository<Director>(_context));
            }
        }

        public IGenericRepository<Genre> GenreRepository
        {
            get
            {
                return _genreRepository ?? (_genreRepository = new GenericRepository<Genre>(_context));
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
