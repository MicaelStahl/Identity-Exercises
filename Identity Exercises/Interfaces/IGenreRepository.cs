using Identity_Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Exercises.Interfaces
{
    public interface IGenreRepository
    {
        // (C)RUD
        Genre CreateGenre(Genre genre);

        // C(R)UD
        Genre FindGenre(int? id);
        Genre FindGenreWithSongs(int? id);

        //CR(U)D
        Genre EditGenre(Genre genre);

        // CRU(D)
        bool DeleteGenre(int? id);
    }
}
