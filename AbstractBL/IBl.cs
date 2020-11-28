using System.Collections.Generic;

namespace AbstractBLL
{
    public interface IBl<T>
    {
        List<T> GetAll();
        string Add(T t);
        string Delete(string id);
        T GetById(string id);
    }
}