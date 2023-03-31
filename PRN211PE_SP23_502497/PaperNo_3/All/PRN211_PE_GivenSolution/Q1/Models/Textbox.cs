using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Textbox
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Readonly { get; set; }
    }
}
