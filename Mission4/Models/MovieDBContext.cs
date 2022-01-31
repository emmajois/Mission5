using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext (DbContextOptions<MovieDBContext> options) : base (options)
        {

        }
        
        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }

        //Seeding in some of my favorite movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<FavoriteMovie>().HasData(
                new FavoriteMovie
                {
                    MovieId = 1,
                    Category = "Superhero",
                    Title = "Spider Man: No Way home",
                    Year = 2021,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "",
                    Notes = ""
                },
                new FavoriteMovie
                {
                    MovieId = 2,
                    Category = "Action",
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "",
                    Notes = ""
                },
                new FavoriteMovie
                {
                    MovieId = 3,
                    Category = "Disney",
                    Title = "Frozen",
                    Year = 2013,
                    Director = "Chris Buck, Jennifer Lee",
                    Rating = "PG",
                    Edited = false,
                    Lent = "",
                    Notes = ""
                }
            );
        }
    }
}
