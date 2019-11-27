using System;
using System.Collections.Generic;

namespace UnitOfWorkNRepositoryPattern.Data.Models
{
    public partial class Director
    {
        public int DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
