using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using Vodafone.Models;
using Rotativa;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;

namespace Vodafone.Controllers
{
    public class HomeController : Controller
    {
        private EnergyMarketPriceTestEntities2 db = new EnergyMarketPriceTestEntities2();
        [HttpGet]
        public ViewResult Index(Keyfromlink input)
        {
            if (input.key != null)
            {
                var formulaid = db.fnFormulaByKey(input.key).FirstOrDefault().ID;
                // string k = key;
                var FormulaVPC = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year);
                if (input.code != null) FormulaVPC = FormulaVPC.Where(p => p.CalendarCode == input.code).OrderByDescending(p => p.Year);
                var FormulaVPCList = FormulaVPC.ToList();

                ViewBag.High = FormulaVPCList.Take(1).FirstOrDefault().High;
                ViewBag.Medium = FormulaVPCList.Take(1).FirstOrDefault().Medium;
                ViewBag.Low = FormulaVPCList.Take(1).FirstOrDefault().Low;
                ViewBag.MinMarket_Value = FormulaVPCList.Take(1).FirstOrDefault().MinMarket_Value;
                ViewBag.MinMarket_Date = FormulaVPCList.Take(1).FirstOrDefault().MinMarket_Date;
                ViewBag.VolumeTotal = FormulaVPCList.Take(1).FirstOrDefault().VolumeTotal;
                ViewBag.MaxPriceFixed = FormulaVPCList.Take(1).FirstOrDefault().MaxPriceFixed;
                ViewBag.MaxPriceFixed1 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().MaxPriceFixed;
                ViewBag.MaxPriceFixed2 = FormulaVPCList.Skip(2).Take(1).FirstOrDefault().MaxPriceFixed;
                ViewBag.VolumeFixProcent = FormulaVPCList.Take(1).FirstOrDefault().VolumeFixProcent;
                ViewBag.VolumeFixProcent1 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().VolumeFixProcent;
                ViewBag.VolumeFixProcent2 = FormulaVPCList.Skip(2).Take(1).FirstOrDefault().VolumeFixProcent;
            }
            else {
                ViewBag.High = 0;
                ViewBag.Medium = 0;
                ViewBag.Low = 0;
                ViewBag.MinMarket_Value = 0;
                ViewBag.MinMarket_Date = DateTime.Now;
                ViewBag.VolumeTotal = 0;
                ViewBag.MaxPriceFixed = 0;
                ViewBag.MaxPriceFixed1 = 0;
                ViewBag.MaxPriceFixed2 = 0;
                ViewBag.VolumeFixProcent = 0;
                ViewBag.VolumeFixProcent1 = 0;
                ViewBag.VolumeFixProcent2 = 0;
            }
            return View();
        }
        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult ExportPDF()
        {
            return new Rotativa.MVC.ActionAsPdf("Index")
            {
                FileName = Server.MapPath("~/Content/Report.pdf")
            };
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public class Keyfromlink
    {
        public string key { get; set; }
        public string code { get; set; }
    }
}