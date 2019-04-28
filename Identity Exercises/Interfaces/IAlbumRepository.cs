using Identity_Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Exercises.Interfaces
{
    public interface IAlbumRepository
    {
        // (C)RUD
        Album CreateAlbum(Album album);

        //C(R)UD
        Album FindAlbum(int? id);
        Album FindAlbumWithSongs(int? id);

        // CR(U)D
        Album EditAlbum(Album album);

        // CRU(D)
        bool DeleteAlbum(int? id);
    }
}
