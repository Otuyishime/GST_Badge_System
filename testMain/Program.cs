using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_Badge_System.DAO;

namespace testMain
{
    class Program
    {
        static void Main(string[] args)
        {
            BadgeDAO badgedao = new BadgeDAO();
            int actual = badgedao.ImportBadges(@"C:\Users\olivi\OneDrive\Documents\Intro Software Tools\Projects\GST_Badge_System\GST_Badge_System\GST_Badge_System.DAO\Data\StaffStudentBadges.csv").Count;
            Console.WriteLine("Num elements: " + actual);
        }
    }
}
