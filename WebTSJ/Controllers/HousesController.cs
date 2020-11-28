using System.Collections.Generic;
using System.Web.Mvc;
using AbstractBLL;
using AutoMapper;
using DistrictBL;
using Entities;
using HouseBL;
using HouseCounterBL;
using ManageCompanyBL;
using WebTSJ.Models;

namespace WebTSJ.Controllers
{
    public class HousesController : Controller
    {
        private readonly IBl<House> _houseLogic;
        private readonly IBl<ManageCompany> _companyLogic;
        private readonly IBl<District> _districtLogic;
        private readonly IBl<HouseCounter> _counterLogic;
        private readonly IMapper _mapper;

        public HousesController()
        {
        }

        public HousesController(IBl<House> houseLogic, IBl<ManageCompany> companyLogic, IBl<District> districtLogic,
            IBl<HouseCounter> counterLogic, IMapper mapper)
        {
            _houseLogic = houseLogic;
            _companyLogic = companyLogic;
            _districtLogic = districtLogic;
            _counterLogic = counterLogic;
            _mapper = mapper;
        }

        public ActionResult Houses()
        {
            ViewData["companies"] = _mapper.Map<IEnumerable<ManageCompanyModel>>(_companyLogic.GetAll());
            ViewData["districts"] = _mapper.Map<IEnumerable<DistrictModel>>(_districtLogic.GetAll());
            IEnumerable<HouseModel> houses;
            if (!TempData.ContainsKey("houses"))
            {
                houses = _mapper.Map<IEnumerable<HouseModel>>(_houseLogic.GetAll());
            }
            else
            {
                houses = (IEnumerable<HouseModel>) TempData.Peek("houses");
            }
            return View(houses);
        }

        
        public ActionResult CompanyHouses(string companyTitle)
        {
            var houses = _mapper.Map<List<HouseModel>>(_houseLogic.GetAll());
            TempData["companyTitle"] = companyTitle;
            TempData["houses"] = houses.FindAll(h => h.IdCompany == companyTitle);
            return RedirectToAction("Houses");
        }

        public ActionResult AddHouse(string address, int podezd, int floor, string district, string company)
        {
            var result = _houseLogic.Add(new House(address, podezd, floor, district, company));
            _counterLogic.Add(new HouseCounter(address, 0, 0, 0));
            return RedirectToAction("CompanyHouses", new {companyTitle = company});
        }

        public ActionResult DeleteHouse(string address)
        {
            var result = _houseLogic.Delete(address);
            return RedirectToAction("CompanyHouses", new {companyTitle = TempData["companyTitle"]});
        }
    }
}