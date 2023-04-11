using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace laboratorio3.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}