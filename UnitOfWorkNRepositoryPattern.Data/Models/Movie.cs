using System;
using System.Collections.Generic;

namespace UnitOfWorkNRepositoryPattern.Data.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? GenreId { get; set; }
        public int? DirectorId { get; set; }

        public virtual Director Director { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
