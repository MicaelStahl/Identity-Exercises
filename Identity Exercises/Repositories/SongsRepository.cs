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
    public class SongsRepository : ISongsRepository
    {
        private readonly MusicDbContext _db;

        public SongsRepository(MusicDbContext db)
        {
            _db = db;
        }

        public List<Songs> AllSongs()
        {
            return _db.Songs
                .Include(x=>x.Album)
                .Include(x=>x.Genre)
                .Where(x => x.Id == x.Id).ToList();
        }

        public Songs CreateSong(Songs songs)
        {
            if (!string.IsNullOrWhiteSpace(songs.Title) ||
                !string.IsNullOrWhiteSpace(songs.ArtistName))
            {
                if (songs.Genre != null || songs.Album != null)
                {
                    var newSong = new Songs()
                    {
                        Title = songs.Title,
                        Album = songs.Album,
                        Genre = songs.Genre,
                        ArtistName = songs.ArtistName
                    };

                    if (newSong != null)
                    {
                        _db.Songs.Add(newSong);

                        _db.SaveChanges();

                        return newSong;
                    }
                }
            }
            return null;
        }

        public bool DeleteSong(int? id)
        {
            if (id == null || id == 0)
            {
                return false;
            }

            var song = _db.Songs.SingleOrDefault(x => x.Id == id);

            if (song != null)
            {
                _db.Songs.Remove(song);

                _db.SaveChanges();

                return true;
            }
            return false;
        }

        public Songs EditSong(Songs songs)
        {
            if (!string.IsNullOrWhiteSpace(songs.Title) ||
                !string.IsNullOrWhiteSpace(songs.ArtistName))
            {
                if (songs.Genre != null || songs.Album != null)
                {
                    var newSong = _db.Songs.SingleOrDefault(x => x.Id == songs.Id);

                    if (newSong != null)
                    {
                        newSong.Title = songs.Title;
                        newSong.Genre = songs.Genre;
                        newSong.Album = songs.Album;
                        newSong.ArtistName = songs.ArtistName;

                        _db.SaveChanges();

                        return newSong;
                    }
                }
            }
            return null;
        }

        public Songs FindSong(int? id)
        {
            if (id == null || id == 0)
            {
                return null;
            }

            var song = _db.Songs.SingleOrDefault(x => x.Id == id);

            if (song != null)
            {
                return song;
            }
            return null;
        }

        public Songs FindSongWithEverything(int? id)
        {
            if (id == null || id == 0)
            {
                return null;
            }

            var song = _db.Songs
                .Include(x => x.Genre)
                .Include(x => x.Album)
                .SingleOrDefault(x => x.Id == id);

            if (song != null)
            {
                return song;
            }
            return null;
        }
    }
}
