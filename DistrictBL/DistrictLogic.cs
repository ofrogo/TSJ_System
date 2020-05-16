using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using DistrictDAL;
using Entities;

namespace DistrictBL
{
    public class DistrictLogic : IDistrictBl
    {
        private IDistrictDao _districtDao;
        public DistrictLogic()
        {
            _districtDao = new DistrictDao();
        }

        public List<District> GetAll()
        {
            return (List<District>) _districtDao.GetAll();
        }

        public string Delete(string id)
        {
            var res = _districtDao.Delete(id);
            return res > 0 ? $"Было удалено {res} строк." : "Произошла ошибка при удалении.";
        }

        public string Add(District district)
        {
            var res = _districtDao.Add(district);
            return res > 0 ? $"Было добавлено {res} строк." : "Произошла ошибка при добавлении.";
        }
    }
}