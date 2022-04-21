﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Uyflix.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCategory> MoviesCategories { get; set; }
    }
}
