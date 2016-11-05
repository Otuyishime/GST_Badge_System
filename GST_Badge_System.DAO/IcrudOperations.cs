using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GST_Badge_System.DAO
{
    public interface IcrudOperations<T>
    {
        // create
        T create(T element);

        // retrieve
        T retrieve(object id);

        // update
        T update(T element);

        // delete
        T delete(object id);

        // list
        T list();
    }
}
