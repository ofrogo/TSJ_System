using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using Entities;
using ReceiptDAL;

namespace ReceiptBL
{
    public class ReceiptLogic : IBl<Receipt>
    {
        private readonly IDao<Receipt> _dao;

        public ReceiptLogic()
        {
            _dao = new ReceiptDao();
        }
        
        public List<Receipt> GetAll()
        {
            return (List<Receipt>) _dao.GetAll();
        }

        public string Add(Receipt t)
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