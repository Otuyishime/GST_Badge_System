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
            int StudToPeer_Badge_Id = new BadgeGiveTypeDAO()["Student to peer"].BGT_Id;
            Console.WriteLine("Id: " + StudToPeer_Badge_Id);
        }
    }
}
