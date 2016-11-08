using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GST_Badge_System.DAO
{
    /*
     This class will be used to read/write all the user data from the data database
     */
    public class UserDAO
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=gst_badge_system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public User create(User user)
        {
            if (user == null)
            {
                throw new Exception("User update failed, the passed user is null!");
            }

            string name = user.User_Name;
            string email = user.User_Email;
            string user_type = user.User_Type;

            string sql = @"INSERT INTO Users (User_Name, User_Email, User_Type) VALUES ( @name , @email , @user_type )";
            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.Execute(sql, new { name, email, user_type});
                return new User { User_Name = name, User_Email = email, User_Type = user_type };
            }

        }

        public int delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                throw new Exception("User deletion failed. Entered a wrong ID");
            }

            string sql = @"DELETE FROM Users WHERE User_Id = @id";
            using(var conn = new SqlConnection(connectionString: connectionString))
            {
                int result = conn.Execute(sql);
                return result;
            }
        }

        // Return all users without badges
        public List<User> list()
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.Query<User>("Select * From Users").AsList();
            }
        }

        // retrieve user with received badges
        public List<BadgeTransaction> retrieveUserReceivedBadges(string user_Id)
        {
            if (String.IsNullOrEmpty(user_Id))
            {
                throw new Exception("Failed to retrieve user. Wrong Name.");
            }
            
            using (var conn = new SqlConnection(connectionString))
            { 
                string sql = @"SELECT Badge.*, Users.*, BadgeTransaction.Badge_Comment, BadgeTransaction.BTrans_Date 
                                From Badge, Users, BadgeTransaction,
                                (SELECT BadgeTransaction.* FROM BadgeTransaction WHERE BadgeTransaction.Reciever = @user_Id) AS A 
                                where Badge.Badge_Id = A.Badge_Id AND Users.User_Id = A.Sender AND Badge.Badge_Id = BadgeTransaction.Badge_Id";

                List<BadgeTransaction> result = conn.Query<Badge, User, BadgeTransaction, BadgeTransaction>(sql,
                    (b, usend, bt) => {
                        bt.Badge = b;
                        bt.Sender = usend;
                        
                        return bt;
                    }, new { user_Id },
                    splitOn: "User_Id, Badge_Comment"
                    ).AsList();

                return result;
            }
        }

        // retrieve user with sent badges
        public List<BadgeTransaction> retrieveUserSentBadges(string user_Id)
        {
            if (String.IsNullOrEmpty(user_Id))
            {
                throw new Exception("Failed to retrieve user. Wrong Name.");
            }

            using (var conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT Badge.*, Users.*, BadgeTransaction.Badge_Comment, BadgeTransaction.BTrans_Date 
                                From Badge, Users, BadgeTransaction,
                                (SELECT BadgeTransaction.* FROM BadgeTransaction WHERE BadgeTransaction.Sender = @user_Id) AS A 
                                where Badge.Badge_Id = A.Badge_Id AND Users.User_Id = A.Reciever AND Badge.Badge_Id = BadgeTransaction.Badge_Id";

                List<BadgeTransaction> result = conn.Query<Badge, User, BadgeTransaction, BadgeTransaction>(sql,
                    (b, ureciev, bt) => {
                        bt.Badge = b;
                        bt.Receiver = ureciev;

                        return bt;
                    }, new { user_Id },
                    splitOn: "User_Id, Badge_Comment"
                    ).AsList();

                return result;
            }
        }

        // update the user information
        public User update(User user, string oldUserName)
        {
            if (user == null || String.IsNullOrEmpty(oldUserName))
            {
                throw new Exception("User update failed, the passed user is null!");
            }

            string name = user.User_Name;
            string email = user.User_Email;
            string user_type = user.User_Type;

            string sql = @"UPDATE TABLE Users SET User_Name = @name, User_Email = @email, User_Type = @user_type WHERE User_Name = @oldUserName";

            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.Execute(sql, new { name, email, user_type, oldUserName});
                return new User { User_Name = name, User_Email = email, User_Type = user_type };
            }
        }

        public List<User> importUsers()
        {
            string line;
            List<User> users = new List<User>();

            // Read the file and display it line by line.
            string fileName = @"C:\Users\olivi\OneDrive\Documents\Intro Software Tools\Projects\GST_Badge_System\GST_Badge_System\GST_Badge_System.DAO\Data\BadgeSystemPeople.csv";

            using (System.IO.StreamReader file = new System.IO.StreamReader(fileName))
            {
                file.ReadLine();    // Read to get rid of the first line
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    String[] splittedFields = line.Split(',');

                    User temp_user = new User();

                    if (!String.IsNullOrEmpty(splittedFields[0]) &&
                        !String.IsNullOrEmpty(splittedFields[1]))
                    {
                        temp_user.User_Name = splittedFields[0];
                        temp_user.User_Email = splittedFields[1];
                    }
                    else
                    {
                        throw new Exception("One or more parameters failed to parse!");
                    }

                    users.Add(temp_user);
                }
            }

            return users;
        }

        public int uploadUsers()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string name, email, user_type;

                foreach(User user in importUsers())
                {
                    name = user.User_Name;
                    email = user.User_Email;
                    user_type = "stu";

                    string sql = @"INSERT INTO Users (User_Name, User_Email, User_Type) VALUES ( @name , @email , @user_type )";
                    var result = conn.Execute(sql, new { name, email, user_type });
                }

                return 1;
            }
        }
    }
}
