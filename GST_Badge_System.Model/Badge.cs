using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GST_Badge_System.Model
{
    public class Badge
    {
        public string Badge_ID { get; set; }
        public string Badge_Name { get; set; }
        public string Badge_Descript { get; set; }
        public string Badge_ActiveDate { get; set; }
        public string Badge_RetireDate { get; set; }
        public byte[] Badge_Image { get; set; }

        public string Badge_Status { get; set; }
        public BadgeType BadgeType { get; set; }
        public BadgeGiveType BadgeGiveType { get; set; }
    }
}
