using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.models
{
    public class CompletedSet
    {
        public int CompletedSetID { get; set; }
        public int SetID { get; set; }
        public Set Set { get; set; }
        public long Time { get; set; }
        public int Duration { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
