using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using BillDAL;
using Entities;

namespace BillBL
{
    public class BillLogic : IBl<Bill>
    {
        private readonly IDao<Bill> _dao;

        public BillLogic()
        {
            _dao = new BillDao();
        }

        public List<Bill> GetAll()
        {
            return (List<Bill>) _dao.GetAll();
        }

        public string Add(Bill t)
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