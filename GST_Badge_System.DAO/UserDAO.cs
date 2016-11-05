using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;

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
    }
}
