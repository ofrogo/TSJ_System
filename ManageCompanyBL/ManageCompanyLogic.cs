using System.Collections.Generic;
using AbstractBLL;
using AbstractDAL;
using Entities;
using ManageCompanyDAL;

namespace ManageCompanyBL
{
    public class ManageCompanyLogic : IBl<ManageCompany>
    {
        private readonly IDao<ManageCompany> _dao;

        public ManageCompanyLogic()
        {
            _dao = new ManageCompanyDao();
        }
        
        public List<ManageCompany> GetAll()
        {
            return (List<ManageCompany>) _dao.GetAll();
        }

        public string Add(ManageCompany t)
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