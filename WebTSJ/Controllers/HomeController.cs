using System.Web.Mvc;
using AbstractBLL;
using Entities;
using JilezBL;

namespace WebTSJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBl<Jilez> _jilezLogic;

        public HomeController(IBl<Jilez> jilezLogic)
        {
            _jilezLogic = jilezLogic;
        }

        public HomeController()
        {
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login)
        {
            if (login == "admin")
            {
                TempData["login"] = login;
                return RedirectToAction("AllCompanies", "Companies");
            }

            var jilezes = _jilezLogic.GetAll();
            if (jilezes.Exists(jilez => jilez.PassportId == login))
            {
                TempData["login"] = login;
                return RedirectToAction("JilezInfo", "CurrentInfo", new {passport = login});
            }
            else
                return RedirectToAction("Index");
        }
    }
}