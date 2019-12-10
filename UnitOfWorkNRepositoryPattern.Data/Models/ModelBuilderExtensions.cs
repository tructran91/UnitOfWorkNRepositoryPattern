using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkNRepositoryPattern.Data.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().HasData(
                new Director() { DirectorId = 1, FirstName = "Steven", LastName = "Spielberg" },
                new Director() { DirectorId = 2, FirstName = "James", LastName = "Cameron" },
                new Director() { DirectorId = 3, FirstName = "Martin", LastName = "Scorsese" },
                new Director() { DirectorId = 4, FirstName = "Quentin", LastName = "Tarantino" },
                new Director() { DirectorId = 5, FirstName = "Christopher", LastName = "Nolan" });

            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = 1, Name = "Hành động" },
                new Genre() { GenreId = 2, Name = "Hoạt hình" },
                new Genre() { GenreId = 3, Name = "Adult" });

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    MovieId = 1,
                    Title = "Nhà tù Shawshank (The Shawshank Redemption)",
                    Language = "English",
                    Rating = 5,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 1,
                    GenreId = 1
                }, new Movie()
                {
                    MovieId = 2,
                    Title = "Bố già (The Godfather)",
                    Language = "Vietnamese",
                    Rating = 5,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 1,
                    GenreId = 1
                }, new Movie()
                {
                    MovieId = 3,
                    Title = "Bố già phần II (The Godfather Part II)",
                    Language = "Vietnamese",
                    Rating = 4,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 2,
                    GenreId = 1
                },
                new Movie()
                {
                    MovieId = 4,
                    Title = "Kỵ sĩ bóng đêm (The Dark Knight)",
                    Language = "Vietnamese",
                    Rating = 5,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 2,
                    GenreId = 2
                }, new Movie()
                {
                    MovieId = 5,
                    Title = "12 người đàn ông giận dữ (12 Angry Men)",
                    Language = "Vietnamese",
                    Rating = 3,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 3,
                    GenreId = 2
                }, new Movie()
                {
                    MovieId = 6,
                    Title = "Bản danh sách của Schindler (Schindler's List)",
                    Language = "Vietnamese",
                    Rating = 3,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 3,
                    GenreId = 3
                }, new Movie()
                {
                    MovieId = 7,
                    Title =
                        "Chúa tể những chiếc nhẫn: Sự trở lại của nhà vua (Lord of the Rings: The Return of the King)",
                    Language = "Vietnamese",
                    Rating = 4,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 4,
                    GenreId = 3
                }, new Movie()
                {
                    MovieId = 8,
                    Title = "Chuyện Tào Lao (Pulp Fiction)",
                    Language = "English",
                    Rating = 3,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 5,
                    GenreId = 1
                }, new Movie()
                {
                    MovieId = 9,
                    Title = "Thiện, ác, tà (The Good, the Bad and the Ugly)",
                    Language = "English",
                    Rating = 5,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 5,
                    GenreId = 2
                }, new Movie()
                {
                    MovieId = 10,
                    Title = "Sàn đấu sinh tử (Fight Club)",
                    Language = "English",
                    Rating = 5,
                    ReleaseDate = DateTime.Now,
                    DirectorId = 5,
                    GenreId = 1
                });
        }
    }
}
