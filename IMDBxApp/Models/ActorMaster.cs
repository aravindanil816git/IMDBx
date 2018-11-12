using System;
using System.Collections.Generic;

namespace IMDBxApp.Models
{
    public partial class ActorMaster
    {
        public long ActorId { get; set; }
        public string ActorName { get; set; }
        public string Sex { get; set; }
        public DateTime? Dob { get; set; }
        public string Bio { get; set; }
    }
}
