using System.Web.Mvc;
using JilezBL;

namespace WebTSJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly JilezLogic _jilezLogic = new JilezLogic();


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
                return RedirectToAction("AllCompanies", "Companies");
            }
            else
                return RedirectToAction("Index");
        }
    }
}