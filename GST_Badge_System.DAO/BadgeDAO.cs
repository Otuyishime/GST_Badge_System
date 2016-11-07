using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

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

        public int delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Badge> list()
        {
            throw new NotImplementedException();
        }

        public Badge retrieve(string id)
        {
            throw new NotImplementedException();
        }

        public Badge update(Badge element)
        {
            throw new NotImplementedException();
        }
    }
}
