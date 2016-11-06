using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace GST_Badge_System.DAO
{
    /*
     This class will be used to read/write all the user data from the data database
     */
    public class UserDAO : IcrudOperations<User>
    {
        public User create(User element)
        {
            throw new NotImplementedException();
        }

        public User delete(object id)
        {
            throw new NotImplementedException();
        }

        public User list()
        {
            throw new NotImplementedException();
        }

        public User retrieve(object id)
        {
            throw new NotImplementedException();
        }

        public User update(User element)
        {
            throw new NotImplementedException();
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
            var connectionString = @"Data Source=TUYISHIME\SQLEXPRESS;Initial Catalog=gst_badge_system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
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
