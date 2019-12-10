﻿using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWorkNRepositoryPattern.Data.Models;

namespace UnitOfWorkNRepositoryPattern.Repos.Contracts
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetTopMoviesInAYear(int year, int count);
    }
}