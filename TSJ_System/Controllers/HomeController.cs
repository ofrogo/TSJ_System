using System.Collections.Generic;
using System.Web.Mvc;
using Entities;
using JilezBL;

namespace TSJ_System.Controllers
{
    public class HomeController : Controller
    {
        private JilezLogic _jilezLogic = new JilezLogic();
        private List<Jilez> _jilezes;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login)
        {
            if (login == "admin")
            {
                return RedirectToAction("Company","Admin");
            }

            _jilezes = _jilezLogic.GetAll();
            if (_jilezes.Exists(jilez => jilez.PassportId == login))
                return RedirectToAction("Jilez", "User", new {login = login});
            else
                return RedirectToAction("Index");
        }

        
    }
}