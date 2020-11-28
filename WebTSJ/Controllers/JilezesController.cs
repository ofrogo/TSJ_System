using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AbstractBLL;
using Entities;
using FloatCounterBL;
using HouseBL;
using HouseCounterBL;
using JilezBL;

namespace WebTSJ.Controllers
{
    public class JilezesController : Controller
    {
        private readonly IBl<Jilez> _jilezLogic;
        private readonly IBl<House> _houseLogic;
        private readonly IBl<HouseCounter> _houseCounterLogic;
        private readonly IBl<FloatCounter> _counterLogic;

        public JilezesController()
        {
        }

        public JilezesController(IBl<Jilez> jilezLogic, IBl<House> houseLogic, IBl<HouseCounter> houseCounterLogic, IBl<FloatCounter> counterLogic)
        {
            _jilezLogic = jilezLogic;
            _houseLogic = houseLogic;
            _houseCounterLogic = houseCounterLogic;
            _counterLogic = counterLogic;
        }


        public ActionResult Jilezes()
        {
           
            ViewData["addresses"] = _houseLogic.GetAll();
            List<Jilez> jilezes;
            if (!TempData.ContainsKey("jilezes"))
            {
                jilezes = _jilezLogic.GetAll();
            }
            else
            {
                jilezes = (List<Jilez>) TempData.Peek("jilezes");
            }

            return View(jilezes);
        }

        [HttpPost]
        public ActionResult SetHouseCounter(int water, int gas, int electricity)
        {
            if (_houseCounterLogic.GetAll().Exists(c => c.Id == (string) TempData.Peek("jilezAddress")))
            {
                _houseCounterLogic.Delete((string) TempData.Peek("jilezAddress"));
            }

            _houseCounterLogic.Add(new HouseCounter((string) TempData.Peek("jilezAddress"), water, gas, electricity));
            TempData["water"] = water;
            TempData["gas"] = gas;
            TempData["electricity"] = electricity;
            return RedirectToAction("Jilezes");
        }

        public ActionResult HouseJilez(string houseAddress)
        {
            var jilezes = _jilezLogic.GetAll();
            TempData["jilezAddress"] = houseAddress;
            TempData["jilezes"] = jilezes.FindAll(j => j.HouseAddress == houseAddress);
            var counter = _houseCounterLogic.GetById(houseAddress);
            TempData["water"] = counter.Water;
            TempData["gas"] = counter.Gas;
            TempData["electricity"] = counter.Electricity;
            return RedirectToAction("Jilezes");
        }

        [HttpPost]
        public ActionResult AddJilez(string fsl, string passport, int flat, string address)
        {
            var result = _jilezLogic.Add(new Jilez(passport, fsl, flat, address));
            _counterLogic.Add(new FloatCounter(passport, 0, 0, 0));
            return RedirectToAction("HouseJilez", new {houseAddress = TempData["jilezAddress"]});
        }

        public ActionResult DeleteJilez(string passport)
        {
            var result = _jilezLogic.Delete(passport);
            return RedirectToAction("HouseJilez", new {houseAddress = TempData["jilezAddress"]});
        }
    }
}