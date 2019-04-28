using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Exercises.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Title-length can be between 2 to 60 characters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The name of the artist has to be between 2 to 50 characters long.")]
        public string AlbumCreator { get; set; }

        public List<Songs> Songs { get; set; }
    }
}
