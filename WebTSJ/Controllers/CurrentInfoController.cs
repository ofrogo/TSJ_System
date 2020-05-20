using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BillBL;
using Entities;
using FloatCounterBL;
using HouseBL;
using JilezBL;
using ListServicesBL;
using ReceiptBL;
using TsjServiceBL;
using WebTSJ.Models;

namespace WebTSJ.Controllers
{
    public class CurrentInfoController : Controller
    {
        private readonly JilezLogic _jilezLogic = new JilezLogic();
        private readonly BillLogic _billLogic = new BillLogic();
        private readonly ReceiptLogic _receiptLogic = new ReceiptLogic();
        private readonly ListServicesLogic _servicesLogic = new ListServicesLogic();
        private readonly TsjServiceLogic _tsjServiceLogic = new TsjServiceLogic();
        private readonly HouseLogic _houseLogic = new HouseLogic();
        private readonly FloatCounterLogic _counterLogic = new FloatCounterLogic();

        public ActionResult Index()
        {
            var models = (List<JilezInfoModel>) TempData.Peek("JilezInfo");
            return View(models);
        }

        public ActionResult JilezInfo(string passport)
        {
            var jilez = _jilezLogic.GetById(passport);
            TempData["FSL"] = jilez.Fsl;
            TempData["passport"] = passport;
            var bills = _billLogic.GetAll().FindAll(b => b.IdJilez == passport);
            var receipts = _receiptLogic.GetAll();
            var services = _servicesLogic.GetAll();
            var prices = _tsjServiceLogic.GetAll();
            TempData["TsjServices"] = prices;
            var counter = _counterLogic.GetAll().Find(floatCounter => floatCounter.IdOwner == passport);
            TempData["water"] = counter.Water;
            TempData["gas"] = counter.Gas;
            TempData["electricity"] = counter.Electricity;
            var models = new List<JilezInfoModel>();
            foreach (var b in bills)
            {
                var receipt = receipts.Find(r => r.IdBill == b.Id);
                var billServices = services.FindAll(ls => ls.IdBill == b.Id);
                var priceServices = prices.FindAll(ts => billServices.Exists(bs => bs.IdService == ts.IdName));

                var idBill = b.Id;
                var billDate = receipt.BillDate;
                var amount = receipt.Amount;
                var debt = receipt.Debt;
                var balance = receipt.Balance;
                var serviceCount = new Dictionary<string, int>();
                billServices.ForEach(ls => serviceCount.Add(ls.IdService, ls.Amount));
                var servicePrice = new Dictionary<string, int>();
                priceServices.ForEach(ts => servicePrice.Add(ts.IdName, ts.Price));
                models.Add(new JilezInfoModel(idBill, billDate, amount, debt, balance, serviceCount, servicePrice));
            }

            TempData["JilezInfo"] = models;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SetHouseCounter(int water, int gas, int electricity)
        {
            if (_counterLogic.GetAll().Exists(c => c.IdOwner == (string) TempData.Peek("passport")))
            {
                _counterLogic.Delete((string) TempData.Peek("passport"));
            }

            _counterLogic.Add(new FloatCounter((string) TempData.Peek("passport"), water, gas, electricity));
            TempData["water"] = water;
            TempData["gas"] = gas;
            TempData["electricity"] = electricity;
            return RedirectToAction("JilezInfo", new {passport = (string) TempData.Peek("passport")});
        }

        public ActionResult Add()
        {
            var idJilez = (string) TempData.Peek("passport");
            var idCompany = _houseLogic.GetById(_jilezLogic.GetById(idJilez).HouseAddress).IdCompany;
            var idBill = Request.Form["idBill"];
            var dateBill = DateTime.Parse(Request.Form["dateBill"]);
            var amount = Convert.ToInt32(Request.Form["amount"]);
            var debt = Convert.ToInt32(Request.Form["debt"]);
            var balance = Convert.ToInt32(Request.Form["balance"]);
            var serviceCount =
                (from ts in _tsjServiceLogic.GetAll()
                    let check = "on".Equals(Request.Form["check-" + ts.IdName])
                    where check
                    select ts).ToDictionary(ts => ts.IdName,
                    ts => Convert.ToInt32(Request.Form["amount-" + ts.IdName]));

            _billLogic.Add(new Bill(idBill, idCompany, idJilez));
            _receiptLogic.Add(new Receipt(idBill, dateBill, amount, debt, balance));
            foreach (var n in serviceCount)
            {
                _servicesLogic.Add(new ListServices(idBill, n.Key, n.Value));
            }

            return RedirectToAction("JilezInfo", new {passport = TempData["passport"]});
        }
    }
}