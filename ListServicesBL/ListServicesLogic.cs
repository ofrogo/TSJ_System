using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using Entities;
using ListServicesDAL;

namespace ListServicesBL
{
    public class ListServicesLogic : IBl<ListServices>
    {
        private readonly IDao<ListServices> _dao;

        public ListServicesLogic(IDao<ListServices> dao)
        {
            _dao = dao;
        }
        
        public List<ListServices> GetAll()
        {
            return (List<ListServices>) _dao.GetAll();
        }

        public string Add(ListServices t)
        {
            var res = _dao.Add(t);
            return res >= 0 ? $"Было добавлено {res} строк." : "Произошла ошибка при добавлении.";
        }

        public string Delete(string id)
        {
            var res = _dao.Delete(id);
            return res >= 0 ? $"Было удалено {res} строк." : "Произошла ошибка при удалении.";
        }

        public ListServices GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}