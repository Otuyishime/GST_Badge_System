using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GST_Badge_System.DAO
{
    class BadgeTransactionDAO
    {
        // add badge transaction: More like send a badge
        public int addBadgeTransaction(string sender, string receiver, string badge, string comment)
        {
            if( !String.IsNullOrEmpty(sender) && !String.IsNullOrEmpty(receiver) && 
                !String.IsNullOrEmpty(badge) && !String.IsNullOrEmpty(comment))
            {
                
            }
            else
            {
                throw new Exception("Failed to send the badge. One or more parameters are wrong.");
            }

            return 1;
        }

    }
}
