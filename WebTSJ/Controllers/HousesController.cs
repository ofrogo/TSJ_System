using System.Collections.Generic;
using System.Web.Mvc;
using AbstractBLL;
using DistrictBL;
using Entities;
using HouseBL;
using HouseCounterBL;
using ManageCompanyBL;

namespace WebTSJ.Controllers
{
    public class HousesController : Controller
    {
        private readonly IBl<House> _houseLogic;
        private readonly IBl<ManageCompany> _companyLogic;
        private readonly IBl<District> _districtLogic;
        private readonly IBl<HouseCounter> _counterLogic;

        public HousesController()
        {
        }

        public HousesController(IBl<House> houseLogic, IBl<ManageCompany> companyLogic, IBl<District> districtLogic, IBl<HouseCounter> counterLogic)
        {
            _houseLogic = houseLogic;
            _companyLogic = companyLogic;
            _districtLogic = districtLogic;
            _counterLogic = counterLogic;
        }

        public ActionResult Houses()
        {
            ViewData["companies"] = _companyLogic.GetAll();
            ViewData["districts"] = _districtLogic.GetAll();
            List<House> houses;
            if (!TempData.ContainsKey("houses"))
            {
                houses = _houseLogic.GetAll();
            }
            else
            {
                houses = (List<House>) TempData.Peek("houses");
            }
            return View(houses);
        }

        
        public ActionResult CompanyHouses(string companyTitle)
        {
            var houses = _houseLogic.GetAll();
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