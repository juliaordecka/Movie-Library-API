﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieLibrary.Application.Models
{
    public class Movie
    {
        public required Guid Id { get; init; }
        public required string Title { get; set; }
        public string Slug => GenerateSlug(); // zwroc wynik GenerateSlug() 
        public required string YearOfRelease { get; set; }
        public required List<string> Genres { get; init; } = new();

        private string GenerateSlug() //zamiast dlugiego nieczytelnego id - ladniejsza identyfikacja filmu
        {
            var sluggedTitle = Regex.Replace(Title, @"[^a-zA-Z0-9\s-]", string.Empty)
                .ToLower().Replace(" ", "-");
            return $"{sluggedTitle}-{YearOfRelease}";
        }
    }
}
