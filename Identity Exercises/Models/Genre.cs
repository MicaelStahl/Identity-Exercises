using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Exercises.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength =2, ErrorMessage = "Title-length can be between 2 to 40 characters long.")]
        public string Title { get; set; }

        public List<Songs> Songs { get; set; }
    }
}
