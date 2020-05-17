using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using Entities;
using HouseDAL;

namespace HouseBL
{
    public class HouseLogic : IBl<House>
    {
        private readonly IDao<House> _dao;

        public HouseLogic()
        {
            _dao = new HouseDao();
        }

        public List<House> GetAll()
        {
            return (List<House>) _dao.GetAll();
        }

        public string Add(House t)
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