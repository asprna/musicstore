﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public class Genre
    {
        public Genre()
        {
            Tracks = new HashSet<Track>();
        }

        public long GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
