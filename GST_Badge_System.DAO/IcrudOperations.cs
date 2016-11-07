using System;
using System.Collections.Generic;

namespace GST_Badge_System.DAO
{
    public interface IcrudOperations<T>
    {
        // create
        T create(T element);

        // retrieve
        T retrieve(string id);

        // update
        T update(T element);

        // delete
        int delete(string id);

        // list
        List<T> list();
    }
}
