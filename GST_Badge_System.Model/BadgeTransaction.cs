using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GST_Badge_System.Model
{
    public class BadgeTransaction
    {
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public Badge Badge { get; set; }
        public DateTime BTrans_Date { get; set; }
    }
}
