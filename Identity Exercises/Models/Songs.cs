using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Exercises.Models
{
    public class Songs
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength =2, ErrorMessage = "Title has to be between 2 to 50 characters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The name of the artist has to be between 2 to 50 characters long.")]
        public string ArtistName { get; set; }

        [Required]
        public Album Album { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}
