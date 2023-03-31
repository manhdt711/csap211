﻿using System;
using System.Collections.Generic;

namespace Q2.Models
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public bool Male { get; set; }
        public DateTime Dob { get; set; }
        public string Nationality { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
