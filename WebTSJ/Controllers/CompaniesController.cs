using System.Collections.Generic;
using System.Web.Mvc;
using AbstractBLL;
using AutoMapper;
using Entities;
using WebTSJ.Models;

namespace WebTSJ.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly IBl<ManageCompany> _companyLogic;
        private readonly IMapper _mapper;

        public CompaniesController()
        {
        }

        public CompaniesController(IBl<ManageCompany> companyLogic, IMapper mapper)
        {
            _companyLogic = companyLogic;
            _mapper = mapper;
        }

        public ActionResult AllCompanies()
        {
            return View(_mapper.Map<IEnumerable<ManageCompanyModel>>(_companyLogic.GetAll()));
        }
        
        public ActionResult AddCompany(string title, string fsl, string address, int count)
        {
            var answer = _companyLogic.Add(_mapper.Map<ManageCompany>(new ManageCompanyModel(title, fsl, address, count)));
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