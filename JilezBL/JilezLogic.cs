using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using Entities;
using JilezDAL;

namespace JilezBL
{
    public class JilezLogic : IBl<Jilez>
    {
        private readonly JilezDao _dao;

        public JilezLogic()
        {
            _dao = new JilezDao();
        }

        public Jilez GetById(string passport)
        {
            return _dao.GetById(passport);
        }

        public List<Jilez> GetAll()
        {
            return (List<Jilez>) _dao.GetAll();
        }

        public string Add(Jilez t)
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