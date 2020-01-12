using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkNRepositoryPattern.Data.Models;
using UnitOfWorkNRepositoryPattern.Repos.Contracts;

namespace UnitOfWorkNRepositoryPattern.Web.Controllers
{
    public class MoviesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Movies
        public IActionResult Index()
        {
            var movies = _unitOfWork.MovieRepository.Get(null, t => t.OrderBy(x => x.Title)).ToList();
            return View(movies);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _unitOfWork.MovieRepository
                .Get(t => t.MovieId == id.Value, null, t => t.Director, t => t.Genre).FirstOrDefault();
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewBag.Director = new SelectList(_unitOfWork.DirectorRepository.GetAll().ToList(), "DirectorId", "FirstName");
            ViewBag.Genre = new SelectList(_unitOfWork.GenreRepository.GetAll().ToList(), "GenreId", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MovieId,Title,Language,Rating,ReleaseDate,GenreId,DirectorId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MovieRepository.Add(movie);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Director = new SelectList(_unitOfWork.DirectorRepository.GetAll().ToList(), "DirectorId", "FirstName", movie.DirectorId);
            ViewBag.Genre = new SelectList(_unitOfWork.GenreRepository.GetAll().ToList(), "GenreId", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _unitOfWork.MovieRepository.GetById(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            ViewBag.Director = new SelectList(_unitOfWork.DirectorRepository.GetAll().ToList(), "DirectorId", "FirstName", movie.DirectorId);
            ViewBag.Genre = new SelectList(_unitOfWork.GenreRepository.GetAll().ToList(), "GenreId", "Name", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MovieId,Title,Language,Rating,ReleaseDate,GenreId,DirectorId")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.MovieRepository.Update(movie);
                    _unitOfWork.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_unitOfWork.MovieRepository.GetById(movie.MovieId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Director = new SelectList(_unitOfWork.DirectorRepository.GetAll().ToList(), "DirectorId", "FirstName", movie.DirectorId);
            ViewBag.Genre = new SelectList(_unitOfWork.GenreRepository.GetAll().ToList(), "GenreId", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _unitOfWork.MovieRepository
                .Get(t => t.MovieId == id.Value, null, t => t.Director, t => t.Genre).FirstOrDefault();
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.MovieRepository.DeleteById(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
