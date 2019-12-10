using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkNRepositoryPattern.Repos;
using UnitOfWorkNRepositoryPattern.Repos.Contracts;

namespace UnitOfWorkNRepositoryPattern.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        public IActionResult Index()
        {
            var movies = _unitOfWork.MovieGenericRepository.GetTopMoviesInAYear(2019, 10);
            return View(movies);
        }
    }
}