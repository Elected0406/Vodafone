using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vodafone.Models;

namespace Vodafone.Controllers
{
    public class HomeController : Controller
    {
        private EnergyMarketPriceTestEntities db = new EnergyMarketPriceTestEntities();
        [HttpGet]
        public ViewResult Index(Keyfromlink keyfromlink)
        {
            var formulaid = 2357;
            ViewBag.High = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderByDescending(p => p.Year).ToList().First().High;  
            ViewBag.Medium = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderByDescending(p => p.Year).ToList().First().Medium;
            ViewBag.Low = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderByDescending(p => p.Year).ToList().First().Low;
            ViewBag.MinMarket_Value = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderByDescending(p => p.Year).ToList().First().MinMarket_Value;
            ViewBag.MinMarket_Date = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderByDescending(p => p.Year).ToList().First().MinMarket_Date;
            ViewBag.VolumeTotal = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderByDescending(p => p.Year).ToList().First().VolumeTotal;
            ViewBag.MaxPriceFixed = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderByDescending(p => p.Year).ToList().First().MaxPriceFixed;
            ViewBag.VolumeFixProcent = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderByDescending(p => p.Year).ToList().First().VolumeFixProcent;
            ViewBag.MaxPriceFixed2 = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderBy(p => p.Year).ToList().First().MaxPriceFixed;
            ViewBag.VolumeFixProcent2 = db.vwFormulaVPCs.Where(p => p.Formula == formulaid).OrderBy(p => p.Year).ToList().First().VolumeFixProcent;
            return View();
        }
        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public class Keyfromlink
    {
        public int Atribute { get; set; }
    }
}