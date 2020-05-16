using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IDistrictDao
    {
        IEnumerable<District> GetAll();
        int Add(District district);
        int Delete(string id);
    }
}