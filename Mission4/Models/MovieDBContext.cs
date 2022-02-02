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
        public DbSet<Category> Category { get; set; }
        public object Responses { get; internal set; }

        //Seeding in some of my favorite movies
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryId= 1, CategoryName="Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 7, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 8, CategoryName = "Television" },
                new Category { CategoryId = 9, CategoryName = "VHS" }
                );

            mb.Entity<FavoriteMovie>().HasData(
                new FavoriteMovie
                {
                    MovieId = 1,
                    CategoryId = 1,
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
                    CategoryId = 1,
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
                    CategoryId = 4,
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
