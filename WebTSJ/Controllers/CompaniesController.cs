using System.Web.Mvc;
using AbstractBLL;
using Entities;
using ManageCompanyBL;

namespace WebTSJ.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly IBl<ManageCompany> _companyLogic;

        public CompaniesController()
        {
        }

        public CompaniesController(IBl<ManageCompany> companyLogic)
        {
            _companyLogic = companyLogic;
        }

        public ActionResult AllCompanies()
        {
            return View(_companyLogic.GetAll());
        }
        
        public ActionResult AddCompany(string title, string fsl, string address, int count)
        {
            var answer = _companyLogic.Add(new ManageCompany(title, fsl, address, count));
            ViewBag.AnswerFromBack = answer;
            return RedirectToAction("AllCompanies");
        }

        public ActionResult DeleteCompany(string title)
        {
            var answer = _companyLogic.Delete(title);
            ViewBag.AnswerFromBack = answer;
            return RedirectToAction("AllCompanies");
        }
    }
}