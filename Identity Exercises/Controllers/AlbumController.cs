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
    public class AlbumController : Controller
    {
        private readonly IAlbumRepository _album;

        public AlbumController(IAlbumRepository album)
        {
            _album = album;
        }

        public IActionResult Index()
        {
            return View(_album.AllAlbums());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                var newAlbum = _album.CreateAlbum(album);

                if (newAlbum != null)
                {
                    return RedirectToAction(nameof(Details), "Album", new { id = album.Id });
                }
                return NotFound();
            }
            return BadRequest();
        }

        public IActionResult Details(int? id)
        {
            if (id != null || id != 0)
            {
                var album = _album.FindAlbumWithSongs(id);

                if (album != null)
                {
                    return View(album);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult EditAlbum(int? id)
        {
            if (id != null || id != 0)
            {
                var album = _album.FindAlbum(id);

                if (album != null)
                {
                    return View(album);
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult EditAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                var newAlbum = _album.EditAlbum(album);

                if (newAlbum != null)
                {
                    return RedirectToAction(nameof(Details), "Album", new { id = newAlbum.Id });
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
                var album = _album.FindAlbum(id);

                if (album != null)
                {
                    return View(album);
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
                var boolean = _album.DeleteAlbum(id);

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