﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GST_Badge_System.Model
{
    public class Badge
    {
        public int Badge_Id { get; set; }
        public string Badge_Name { get; set; }
        public string Badge_Descript { get; set; }
        public string Badge_Notes { get; set; }
        public DateTime Badge_ActivateDate { get; set; }
        public DateTime Badge_RetireDate { get; set; }
        public string Badge_Image { get; set; }

        public BadgeStatus Badge_Status { get; set; }
        public BadgeType BadgeType { get; set; }
        public BadgeGiveType BadgeGiveType { get; set; }
    }
}
