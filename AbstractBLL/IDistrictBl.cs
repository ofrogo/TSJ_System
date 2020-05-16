using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IDistrictBl
    {
        List<District> GetAll();
        string Add(District district);
        string Delete(string id);
    }
}