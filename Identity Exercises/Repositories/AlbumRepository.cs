using Identity_Exercises.Database;
using Identity_Exercises.Interfaces;
using Identity_Exercises.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Exercises.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicDbContext _db;

        public AlbumRepository(MusicDbContext db)
        {
            _db = db;
        }

        public Album CreateAlbum(Album album)
        {
            if (!string.IsNullOrWhiteSpace(album.Title) ||
                !string.IsNullOrWhiteSpace(album.AlbumCreator))
            {
                var newAlbum = new Album() { Title = album.Title, AlbumCreator = album.AlbumCreator, Songs = album.Songs };

                if (newAlbum != null)
                {
                    _db.Album.Add(newAlbum);

                    _db.SaveChanges();

                    return newAlbum;
                }
            }
            return null;
        }

        public bool DeleteAlbum(int? id)
        {
            if (id != null || id != 0)
            {
                var album = _db.Album.SingleOrDefault(x => x.Id == id);

                if (album != null)
                {
                    _db.Album.Remove(album);

                    _db.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public Album EditAlbum(Album album)
        {
            if (!string.IsNullOrWhiteSpace(album.Title) ||
                !string.IsNullOrWhiteSpace(album.AlbumCreator))
            {
                var original = _db.Album.SingleOrDefault(x => x.Id == album.Id);

                if (original != null)
                {
                    original.Title = album.Title;
                    original.AlbumCreator = album.AlbumCreator;
                    original.Songs = album.Songs;

                    _db.SaveChanges();

                    return original;
                }
            }
            return null;
        }

        public Album FindAlbum(int? id)
        {
            if (id != null || id != 0)
            {
                var album = _db.Album.SingleOrDefault(x => x.Id == id);

                if (album != null)
                {
                    return album;
                }
            }
            return null;
        }

        public Album FindAlbumWithSongs(int? id)
        {
            if (id != null || id != 0)
            {
                var album = _db.Album
                    .Include(x => x.Songs)
                    .SingleOrDefault(x => x.Id == id);

                if (album != null)
                {
                    return album;
                }
            }
            return null;
        }
    }
}
