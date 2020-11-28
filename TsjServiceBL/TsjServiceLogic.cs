using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using Entities;
using TsjServiceDAL;

namespace TsjServiceBL
{
    public class TsjServiceLogic : IBl<TsjService>
    {
        private readonly IDao<TsjService> _dao;

        public TsjServiceLogic()
        {
            _dao = new TsjServiceDao();
        }
        
        public List<TsjService> GetAll()
        {
            return (List<TsjService>) _dao.GetAll();
        }

        public string Add(TsjService t)
        {
            var res = _dao.Add(t);
            return res >= 0 ? $"Было добавлено {res} строк." : "Произошла ошибка при добавлении.";
        }

        public string Delete(string id)
        {
            var res = _dao.Delete(id);
            return res >= 0 ? $"Было удалено {res} строк." : "Произошла ошибка при удалении.";
        }

        public TsjService GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}