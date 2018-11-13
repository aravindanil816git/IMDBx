using System;
using System.Collections.Generic;

namespace IMDBxApp.Models
{
    public partial class ProducerMaster
    {
        public long ProdId { get; set; }
        public string ProdName { get; set; }
        public string Sex { get; set; }
        public DateTime? Dob { get; set; }
        public string Bio { get; set; }
    }
}
