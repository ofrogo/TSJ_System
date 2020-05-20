using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using Entities;
using HouseCounterDAL;

namespace HouseCounterBL
{
    public class HouseCounterLogic : IBl<HouseCounter>
    {
        private readonly HouseCounterDao _dao;

        public HouseCounterLogic()
        {
            _dao = new HouseCounterDao();
        }

        public HouseCounter GetById(string id)
        {
            return _dao.GetById(id);
        }

        public List<HouseCounter> GetAll()
        {
            return (List<HouseCounter>) _dao.GetAll();
        }

        public string Add(HouseCounter t)
        {
            var res = _dao.Add(t);
            return res >= 0 ? $"Было добавлено {res} строк." : "Произошла ошибка при добавлении.";
        }

        public string Delete(string id)
        {
            var res = _dao.Delete(id);
            return res >= 0 ? $"Было удалено {res} строк." : "Произошла ошибка при удалении.";
        }
    }
}