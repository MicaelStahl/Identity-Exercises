using Identity_Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Exercises.Interfaces
{
    public interface ISongsRepository
    {
        // (C)RUD
        Songs CreateSong(Songs songs);

        // C(R)UD
        Songs FindSong(int? id);
        Songs FindSongWithEverything(int? id);

        // CR(U)D
        Songs EditSong(Songs songs);

        // CRU(D)
        bool DeleteSong(int? id);
    }
}
