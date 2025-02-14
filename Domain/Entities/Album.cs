﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public class Album
    {
        public Album()
        {
            Tracks = new HashSet<Domain.Track>();
        }

        public long AlbumId { get; set; }
        public string Title { get; set; }
        public long ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
