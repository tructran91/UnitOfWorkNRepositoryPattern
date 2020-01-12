using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWorkNRepositoryPattern.Data.Models;
using UnitOfWorkNRepositoryPattern.Repos.Contracts;

namespace UnitOfWorkNRepositoryPattern.Repos
{
    public class MovieRepository: GenericRepository<Movie>, IMovieRepository
    {
        private readonly MovieDBContext _dbContext;

        public MovieRepository(MovieDBContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<Movie> GetTopMoviesInAYear(int year, int count)
        {
            return GetAll()
                //.Include(m => m.Director).Include(m => m.Genre)
                .Where(t => t.ReleaseDate.Value.Year.Equals(year))
                .OrderByDescending(t => t.Rating)
                .Take(count)
                .ToList();
        }
    }
}
