using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GST_Badge_System.DAO
{
    public class BadgeTransactionDAO
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=gst_badge_system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // add badge transaction: More like send a badge
        public int addBadgeTransaction(string sender, string receiver, string badge, string comment)
        {
            if( !String.IsNullOrEmpty(sender) && !String.IsNullOrEmpty(receiver) && 
                !String.IsNullOrEmpty(badge) && !String.IsNullOrEmpty(comment))
            {
                var badgesender = new UserDAO()[sender].User_Id;
                var badgereceiver = new UserDAO()[receiver].User_Id;
                var sentbadge = new BadgeDAO()[badge].Badge_Id;
                var sendcomment = comment;
                var datetime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

                using(IDbConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"INSERT INTO BadgeTransaction (sender, receiver, Badge_Id, BTrans_Date, Badge_Comment) 
                                    VALUES ( @badgesender, @badgereceiver, @sentbadge.Badge_Id, @datetime, @sendcomment)";
                    return conn.Execute(sql, new { badgesender, badgereceiver, sentbadge, datetime, sendcomment});
                }
            }
            else
            {
                throw new Exception("Failed to send the badge. One or more parameters are wrong.");
            }

            return 1;
        }

    }
}
