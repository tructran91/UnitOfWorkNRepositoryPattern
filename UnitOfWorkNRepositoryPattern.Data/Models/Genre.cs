using System;
using System.Collections.Generic;

namespace UnitOfWorkNRepositoryPattern.Data.Models
{
    public partial class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
