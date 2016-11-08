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
            BadgeTransactionDAO btrdao = new BadgeTransactionDAO();
            btrdao.addBadgeTransaction(sender: "Olivier Tuyishime", receiver: "Jesus Arredondo", badge: "Thumbs Up", comment: "Excellent job!!");
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));   
        }
    }
}
