using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;

namespace GST_Badge_System.DAO
{
    /*
     This class will be used to read/write all the badge data from the data database
     */
    public class BadgeDAO : IcrudOperations<Badge>
    {
        public Badge create(Badge element)
        {
            throw new NotImplementedException();
        }

        public Badge delete(object id)
        {
            throw new NotImplementedException();
        }

        public Badge list()
        {
            throw new NotImplementedException();
        }

        public Badge retrieve(object id)
        {
            throw new NotImplementedException();
        }

        public Badge update(Badge element)
        {
            throw new NotImplementedException();
        }
    }
}
