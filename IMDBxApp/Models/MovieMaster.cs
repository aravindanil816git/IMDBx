using System;
using System.Collections.Generic;

namespace IMDBxApp.Models
{
    public partial class MovieMaster
    {
        public long MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime? ReleaseYear { get; set; }
        public string Plot { get; set; }
        public string Thumbnail { get; set; }
        public long? ProdId { get; set; }
    }
}
