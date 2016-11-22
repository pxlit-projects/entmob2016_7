using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.models
{
    public class Admin
    {
        //addition for a migration
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
