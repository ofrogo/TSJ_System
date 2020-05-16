using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IDao<T>
    {
        IEnumerable<T> GetAll();
        int Add(T T);
        int Delete(string id);        
    }
}