﻿using System;
using System.Collections.Generic;

namespace IMDBxApp.Models
{
    public partial class MovieActorDb
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public long ActorId { get; set; }
    }
}
