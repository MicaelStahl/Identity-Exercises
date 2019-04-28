using Identity_Exercises.Database;
using Identity_Exercises.Models;
using Identity_Exercises.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Identity_Exercises
{
    internal class MusicDbInitializer
    {
        internal static void Initialize(MusicDbContext db, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            db.Database.EnsureCreated();

            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole("Administrator");

                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole("NormalUser");

                roleManager.CreateAsync(role).Wait();
            }

            //---------------------- New Section ----------------------\\

            if (userManager.FindByNameAsync("Micael").Result == null)
            {
                AppUser user = new AppUser();
                user.Email = "Micael@Administrator.com";
                user.UserName = "Micael";
                user.FirstName = "Micael";
                user.SecondName = "Ståhl";
                user.PhoneNumber = "0725539574";

                var result = userManager.CreateAsync(user, "Password!23").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }

            if (userManager.FindByNameAsync("Rikke").Result == null)
            {
                AppUser user = new AppUser();
                user.Email = "Rikke@NormalUser.com";
                user.UserName = "Rikke";
                user.FirstName = "Rikke";
                user.SecondName = "Frederiksen";
                user.PhoneNumber = "123456789";

                var result = userManager.CreateAsync(user, "Password!23").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }

            //---------------------- New Section ----------------------\\

            if (!db.Album.Any())
            {
                var albums = new Album[]
                {
                    new Album{ Title="Top 5 Songs", AlbumCreator="Spotify" },
                    new Album{ Title="Community Favourites", AlbumCreator="Random Artist" }
                };

                db.Album.AddRange(albums);

                db.SaveChanges();

                if (!db.Genre.Any())
                {
                    var genres = new Genre[]
                    {
                        new Genre{ Title="Rock" },
                        new Genre{ Title="EDM" },
                        new Genre{ Title="Metal" },
                        new Genre{ Title="Dubstep" },
                        new Genre{ Title="HipHop" },
                        new Genre{ Title="Pop" }
                    };

                    db.Genre.AddRange(genres);

                    db.SaveChanges();

                    if (!db.Songs.Any())
                    {
                        var songs = new Songs[]
                        {
                            new Songs{ Title="Best Song Ever", ArtistName="One-Direction", Genre=genres[5], Album = albums[1] },
                            new Songs{ Title="Numbers", ArtistName="The Cab", Genre=genres[5], Album=albums[0] },
                            new Songs{ Title="World Away", ArtistName="Tonight Alive", Genre=genres[0], Album=albums[0] },
                            new Songs{ Title="Crab Rave", ArtistName="Noisestorm", Genre=genres[1], Album=albums[0] },
                            new Songs{ Title="Breathing Me In", ArtistName="Koven", Genre=genres[1], Album=albums[0] },
                            new Songs{ Title="Knives and Pens", ArtistName="Black Veil Brides", Genre=genres[2], Album=albums[1] },
                            new Songs{ Title="Decoy World", ArtistName="INTERCOM, Park Avenue", Genre=genres[1], Album=albums[0] },
                            new Songs{ Title="Bangarang", ArtistName="Skrillex", Genre=genres[3], Album=albums[1] },

                        };
                    }
                }
            }
        }
    }
}