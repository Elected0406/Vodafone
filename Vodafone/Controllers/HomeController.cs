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
        private EnergyTerminalNEntities db = new EnergyTerminalNEntities();
        [HttpGet]
        public ViewResult Index(Keyfromlink input)
        {
            if (input.key != null)
            {
                var formulaid = db.fnFormulaByKey(input.key).FirstOrDefault().ID;
                var FormulaVPC = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year);
                var count = FormulaVPC.Count();
                if (input.code != null)
                {
                    FormulaVPC = FormulaVPC.Where(p => p.CalendarCode == input.code).OrderByDescending(p => p.Year);
                    var FormulaVPCList = FormulaVPC.ToList();
                    if (count == 1)
                    {
                        ViewBag.High = FormulaVPCList.Take(1).FirstOrDefault().High;
                        ViewBag.Medium = FormulaVPCList.Take(1).FirstOrDefault().Medium;
                        ViewBag.Low = FormulaVPCList.Take(1).FirstOrDefault().Low;
                        ViewBag.MinMarket_Value = FormulaVPCList.Take(1).FirstOrDefault().MinMarket_Value;
                        ViewBag.MinMarket_Date = FormulaVPCList.Take(1).FirstOrDefault().MinMarket_Date;
                        ViewBag.VolumeTotal = FormulaVPCList.Take(1).FirstOrDefault().VolumeTotal;
                        ViewBag.MaxPriceFixed = FormulaVPCList.Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent = FormulaVPCList.Take(1).FirstOrDefault().VolumeFixProcent;
                    }
                    if (count == 2)
                    {
                        ViewBag.High = FormulaVPCList.Take(1).FirstOrDefault().High;
                        ViewBag.Medium = FormulaVPCList.Take(1).FirstOrDefault().Medium;
                        ViewBag.Low = FormulaVPCList.Take(1).FirstOrDefault().Low;
                        ViewBag.MinMarket_Value = FormulaVPCList.Take(1).FirstOrDefault().MinMarket_Value;
                        ViewBag.MinMarket_Date = FormulaVPCList.Take(1).FirstOrDefault().MinMarket_Date;
                        ViewBag.VolumeTotal = FormulaVPCList.Take(1).FirstOrDefault().VolumeTotal;
                        ViewBag.MaxPriceFixed = FormulaVPCList.Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent = FormulaVPCList.Take(1).FirstOrDefault().VolumeFixProcent;
                        ViewBag.MaxPriceFixed1 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent1 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().VolumeFixProcent;
                    }
                    if (count >= 3)
                    {
                        ViewBag.High = FormulaVPCList.Take(1).FirstOrDefault().High;
                        ViewBag.Medium = FormulaVPCList.Take(1).FirstOrDefault().Medium;
                        ViewBag.Low = FormulaVPCList.Take(1).FirstOrDefault().Low;
                        ViewBag.MinMarket_Value = FormulaVPCList.Take(1).FirstOrDefault().MinMarket_Value;
                        ViewBag.MinMarket_Date = FormulaVPCList.Take(1).FirstOrDefault().MinMarket_Date;
                        ViewBag.VolumeTotal = FormulaVPCList.Take(1).FirstOrDefault().VolumeTotal;
                        ViewBag.MaxPriceFixed = FormulaVPCList.Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent = FormulaVPCList.Take(1).FirstOrDefault().VolumeFixProcent;
                        ViewBag.MaxPriceFixed1 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent1 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().VolumeFixProcent;
                        ViewBag.MaxPriceFixed2 = FormulaVPCList.Skip(2).Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent2 = FormulaVPCList.Skip(2).Take(1).FirstOrDefault().VolumeFixProcent;
                    }
                }
                else
                {
                    if (count == 1)
                    {
                        ViewBag.High = FormulaVPC.Take(1).FirstOrDefault().High;
                        ViewBag.Medium = FormulaVPC.Take(1).FirstOrDefault().Medium;
                        ViewBag.Low = FormulaVPC.Take(1).FirstOrDefault().Low;
                        ViewBag.MinMarket_Value = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Value;
                        ViewBag.MinMarket_Date = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Date;
                        ViewBag.VolumeTotal = FormulaVPC.Take(1).FirstOrDefault().VolumeTotal;
                        ViewBag.MaxPriceFixed = FormulaVPC.Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent = FormulaVPC.Take(1).FirstOrDefault().VolumeFixProcent;
                    }
                    if (count == 2)
                    {
                        ViewBag.High = FormulaVPC.Take(1).FirstOrDefault().High;
                        ViewBag.Medium = FormulaVPC.Take(1).FirstOrDefault().Medium;
                        ViewBag.Low = FormulaVPC.Take(1).FirstOrDefault().Low;
                        ViewBag.MinMarket_Value = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Value;
                        ViewBag.MinMarket_Date = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Date;
                        ViewBag.VolumeTotal = FormulaVPC.Take(1).FirstOrDefault().VolumeTotal;
                        ViewBag.MaxPriceFixed = FormulaVPC.Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent = FormulaVPC.Take(1).FirstOrDefault().VolumeFixProcent;
                        ViewBag.MaxPriceFixed1 = FormulaVPC.Skip(1).Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent1 = FormulaVPC.Skip(1).Take(1).FirstOrDefault().VolumeFixProcent;
                    }
                    if (count >= 3)
                    {
                        ViewBag.High = FormulaVPC.Take(1).FirstOrDefault().High;
                        ViewBag.Medium = FormulaVPC.Take(1).FirstOrDefault().Medium;
                        ViewBag.Low = FormulaVPC.Take(1).FirstOrDefault().Low;
                        ViewBag.MinMarket_Value = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Value;
                        ViewBag.MinMarket_Date = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Date;
                        ViewBag.VolumeTotal = FormulaVPC.Take(1).FirstOrDefault().VolumeTotal;
                        ViewBag.MaxPriceFixed = FormulaVPC.Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent = FormulaVPC.Take(1).FirstOrDefault().VolumeFixProcent;
                        ViewBag.MaxPriceFixed1 = FormulaVPC.Skip(1).Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent1 = FormulaVPC.Skip(1).Take(1).FirstOrDefault().VolumeFixProcent;
                        ViewBag.MaxPriceFixed2 = FormulaVPC.Skip(2).Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent2 = FormulaVPC.Skip(2).Take(1).FirstOrDefault().VolumeFixProcent;
                    }
                }
            }
            else
            {
                ViewBag.High = 0;
                ViewBag.Medium = 0;
                ViewBag.Low = 0;
                ViewBag.MinMarket_Value = 0;
                ViewBag.MinMarket_Date = DateTime.Now;
                ViewBag.VolumeTotal = 0;
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