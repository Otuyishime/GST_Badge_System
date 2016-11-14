using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_Badge_System.DAO;
using GST_Badge_System.Model;
using System.Reflection;

namespace testMain
{
    class Program
    {
        static void Main(string[] args)
        {
            //MailHelper.SendBadgeNotification("olix.tech@gmail.com", "oliviertyishime@gmail.com");
            var assembly = Assembly.GetExecutingAssembly().CodeBase;
            UserDAO userdao = new UserDAO();
            Console.WriteLine("Assembly: " + userdao.importUsers().Count);
        }
    }
}
