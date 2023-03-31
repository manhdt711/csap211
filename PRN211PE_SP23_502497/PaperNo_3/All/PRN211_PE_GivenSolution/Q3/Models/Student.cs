﻿using System;
using System.Collections.Generic;

namespace Q3.Models
{
    public partial class Student
    {
        public Student()
        {
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
