using Identity_Exercises.Models;
using Identity_Exercises.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Exercises.Database
{
    public class MusicDbContext : IdentityDbContext<AppUser>
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) { }

        public DbSet<Songs> Songs { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Album> Album { get; set; }
    }
}
