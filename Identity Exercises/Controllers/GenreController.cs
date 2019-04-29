using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity_Exercises.Interfaces;
using Identity_Exercises.Models;
using Microsoft.AspNetCore.Mvc;

namespace Identity_Exercises.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genre;

        public GenreController(IGenreRepository genre)
        {
            _genre = genre;
        }

        public IActionResult Index()
        {
            return View(_genre.AllGenres());
        }

        [HttpGet]
        public IActionResult CreateGenre()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                var newGenre = _genre.CreateGenre(genre);

                if (newGenre != null)
                {
                    return RedirectToAction(nameof(Details), "Genre", new { id = newGenre.Id });
                }
            }
            return BadRequest();
        }

        public IActionResult Details(int? id)
        {
            if (id != null || id != 0)
            {
                var genre = _genre.FindGenreWithSongs(id);

                if (genre != null)
                {
                    return View(genre);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null || id != 0)
            {
                var genre = _genre.FindGenre(id);

                if (genre != null)
                {
                    return View(genre);
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Edit([Bind("Title")]Genre genre)
        {
            if (ModelState.IsValid)
            {
                var newGenre = _genre.EditGenre(genre);

                if (newGenre != null)
                {
                    return RedirectToAction(nameof(Details), "Genre", new { id = newGenre.Id });
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null || id != 0)
            {
                var genre = _genre.FindGenre(id);

                if (genre != null)
                {
                    return View(genre);
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id != null || id != 0)
            {
                var boolean = _genre.DeleteGenre(id);

                if (boolean)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}