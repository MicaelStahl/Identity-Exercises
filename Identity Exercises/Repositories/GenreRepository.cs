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
    public class GenreRepository : IGenreRepository
    {
        private readonly MusicDbContext _db;

        public GenreRepository(MusicDbContext db)
        {
            _db = db;
        }

        public List<Genre> AllGenres()
        {
            return _db.Genre
                .Include(x=>x.Songs)
                .Where(x => x.Id == x.Id).ToList();
        }

        public Genre CreateGenre(Genre genre)
        {
            if (!string.IsNullOrWhiteSpace(genre.Title))
            {
                var newGenre = new Genre() { Title = genre.Title, Songs = genre.Songs };

                if (newGenre != null)
                {
                    _db.Genre.Add(newGenre);

                    _db.SaveChanges();

                    return newGenre;
                }
            }
            return null;
        }

        public bool DeleteGenre(int? id)
        {
            if (id != null || id != 0)
            {
                var genre = _db.Genre.SingleOrDefault(x => x.Id == id);

                if (genre != null)
                {
                    _db.Genre.Remove(genre);

                    _db.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public Genre EditGenre(Genre genre)
        {
            if (!string.IsNullOrWhiteSpace(genre.Title))
            {
                var original = _db.Genre.SingleOrDefault(x => x.Id == genre.Id);

                if (original != null)
                {
                    original.Title = genre.Title;
                    original.Songs = genre.Songs;

                    _db.SaveChanges();

                    return original;
                }
            }
            return null;
        }

        public Genre FindGenre(int? id)
        {
            if (id != null || id != 0)
            {
                var genre = _db.Genre.SingleOrDefault(x => x.Id == id);

                if (genre != null)
                {
                    return genre;
                }
            }
            return null;
        }

        public Genre FindGenreWithSongs(int? id)
        {
            if (id != null || id != 0)
            {
                var genre = _db.Genre
                    .Include(x => x.Songs)
                    .SingleOrDefault(x => x.Id == id);

                if (genre != null)
                {
                    return genre;
                }
            }
            return null;
        }
    }
}
