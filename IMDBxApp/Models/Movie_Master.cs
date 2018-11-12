using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBxApp.Models
{
    public class Movie_Master
    {
        public MovieMaster movie { get; set; }
        public List<ActorMaster> actors { get; set; }
        public ProducerMaster producer { get; set; }
    }
}
