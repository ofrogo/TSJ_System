using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using Entities;
using FloatCounterDAL;

namespace FloatCounterBL
{
    public class FloatCounterLogic : IBl<FloatCounter>
    {
        private readonly IDao<FloatCounter> _dao;

        public FloatCounterLogic()
        {
            _dao = new FloatCounterDao();
        }
        
        public List<FloatCounter> GetAll()
        {
            return (List<FloatCounter>) _dao.GetAll();
        }

        public string Add(FloatCounter t)
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