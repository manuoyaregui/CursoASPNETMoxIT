﻿namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public short Stock { get; set; }

        public Genre Genre { get; set; }
        public short GenreID { get; set; }
    }
}
