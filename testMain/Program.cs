﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_Badge_System.DAO;
using GST_Badge_System.Model;

namespace testMain
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDAO userdao = new UserDAO();
            string actual = userdao.retrieveWithSentBadges("1")[0].Sender.User_Name;

            Console.WriteLine("Name-sender: " + actual);
        }
    }
}
