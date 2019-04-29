using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity_Exercises.Interfaces;
using Identity_Exercises.Models;
using Microsoft.AspNetCore.Mvc;

namespace Identity_Exercises.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongsRepository _songs;

        public SongsController(ISongsRepository songs)
        {
            _songs = songs;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateSong()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSong(Songs songs)
        {
            if (ModelState.IsValid)
            {
                var newSong = _songs.CreateSong(songs);

                if (newSong != null)
                {
                    return RedirectToAction(nameof(Details), "Songs", new { id = newSong.Id });
                }
                return NotFound();
            }
            return BadRequest();
        }

        public IActionResult Details(int? id)
        {
            if (id != null || id != 0)
            {
                var song = _songs.FindSongWithEverything(id);

                if (song != null)
                {
                    return View(song);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult EditSong(int? id)
        {
            if (id != null || id != 0)
            {
                var song = _songs.FindSong(id);

                if (song != null)
                {
                    return View(song);
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult EditSong(Songs songs)
        {
            if (ModelState.IsValid)
            {
                var newSong = _songs.EditSong(songs);

                if (newSong != null)
                {
                    return RedirectToAction(nameof(Details), "Songs", new { id = newSong.Id });
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
                var song = _songs.FindSong(id);

                if (song != null)
                {
                    return View(song);
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
                var boolean = _songs.DeleteSong(id);

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