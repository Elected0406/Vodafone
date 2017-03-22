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
        private TerminalEntities db = new TerminalEntities();
        [HttpGet]
        public ViewResult Index(Keyfromlink input)
        {

            if (input.key != null)
            {
                var formulaid = db.fnFormulaByKey(input.key).FirstOrDefault().ID;
                ViewBag.raportname = db.fnFormulaByKey(input.key).FirstOrDefault().Name;
                var CurrrencyCode = " ";
                if (db.fnFormulaByKey(input.key).FirstOrDefault().CurrencyCode.ToString() == "GBP")
                {
                    CurrrencyCode = "£";
                }
                if (db.fnFormulaByKey(input.key).FirstOrDefault().CurrencyCode.ToString() == "EUR")
                {
                    CurrrencyCode = "€";
                }
                var UnitName = db.fnFormulaByKey(input.key).FirstOrDefault().UnitName;

                var FormulaVPC = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year);
                var FormulaVPCcode = FormulaVPC.Where(p => p.CalendarCode == input.code).OrderByDescending(p => p.Year);
                var FormulaVPCList = FormulaVPCcode.ToList();
                var count = FormulaVPCList.Count();
                var count2 = FormulaVPC.Count();
                if (input.code != null)
                {

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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPCList.Take(1).FirstOrDefault().PolicyCompliant;
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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPCList.Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant2 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().PolicyCompliant;
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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPCList.Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant2 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant3 = FormulaVPCList.Skip(2).Take(1).FirstOrDefault().PolicyCompliant;
                    }
                }
                else
                {
                    if (count2 == 1)
                    {
                        ViewBag.High = FormulaVPC.Take(1).FirstOrDefault().High;
                        ViewBag.Medium = FormulaVPC.Take(1).FirstOrDefault().Medium;
                        ViewBag.Low = FormulaVPC.Take(1).FirstOrDefault().Low;
                        ViewBag.MinMarket_Value = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Value;
                        ViewBag.MinMarket_Date = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Date;
                        ViewBag.VolumeTotal = FormulaVPC.Take(1).FirstOrDefault().VolumeTotal;
                        ViewBag.MaxPriceFixed = FormulaVPC.Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent = FormulaVPC.Take(1).FirstOrDefault().VolumeFixProcent;
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPC.Take(1).FirstOrDefault().PolicyCompliant;
                    }
                    if (count2 == 2)
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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPC.Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant2 = FormulaVPC.Skip(1).Take(1).FirstOrDefault().PolicyCompliant;
                    }
                    if (count2 >= 3)
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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPC.Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant2 = FormulaVPC.Skip(1).Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant3 = FormulaVPC.Skip(2).Take(1).FirstOrDefault().PolicyCompliant;
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
                ViewBag.CurrrencyCode = "null";
                ViewBag.UnitName = "null";
                ViewBag.raportname = "null";
                ViewBag.Mediumx = " ";
                ViewBag.Lowx = " ";
                ViewBag.Highx = " ";
                ViewBag.UltraLowx = " ";
                ViewBag.PolicyCompliant1 = "null";
                ViewBag.PolicyCompliant2 = "null";
                ViewBag.PolicyCompliant3 = "null";
            }
            return View();
        }
        public ActionResult GetReport(Keyfromlink input)
        {
            if (input.key != null)
            {
                var formulaid = db.fnFormulaByKey(input.key).FirstOrDefault().ID;
                ViewBag.raportname = db.fnFormulaByKey(input.key).FirstOrDefault().Name;
                var CurrrencyCode = " ";
                if (db.fnFormulaByKey(input.key).FirstOrDefault().CurrencyCode.ToString() == "GBP")
                {
                    CurrrencyCode = "£";
                }
                if (db.fnFormulaByKey(input.key).FirstOrDefault().CurrencyCode.ToString() == "EUR")
                {
                    CurrrencyCode = "€";
                }
                var UnitName = db.fnFormulaByKey(input.key).FirstOrDefault().UnitName;

                var FormulaVPC = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year);
                var FormulaVPCcode = FormulaVPC.Where(p => p.CalendarCode == input.code).OrderByDescending(p => p.Year);
                var FormulaVPCList = FormulaVPCcode.ToList();
                var count = FormulaVPCList.Count();
                var count2 = FormulaVPC.Count();
                if (input.code != null)
                {

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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPCList.Take(1).FirstOrDefault().PolicyCompliant;
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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPCList.Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant2 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().PolicyCompliant;
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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPCList.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPCList.Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant2 = FormulaVPCList.Skip(1).Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant3 = FormulaVPCList.Skip(2).Take(1).FirstOrDefault().PolicyCompliant;
                    }
                }
                else
                {
                    if (count2 == 1)
                    {
                        ViewBag.High = FormulaVPC.Take(1).FirstOrDefault().High;
                        ViewBag.Medium = FormulaVPC.Take(1).FirstOrDefault().Medium;
                        ViewBag.Low = FormulaVPC.Take(1).FirstOrDefault().Low;
                        ViewBag.MinMarket_Value = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Value;
                        ViewBag.MinMarket_Date = FormulaVPC.Take(1).FirstOrDefault().MinMarket_Date;
                        ViewBag.VolumeTotal = FormulaVPC.Take(1).FirstOrDefault().VolumeTotal;
                        ViewBag.MaxPriceFixed = FormulaVPC.Take(1).FirstOrDefault().MaxPriceFixed;
                        ViewBag.VolumeFixProcent = FormulaVPC.Take(1).FirstOrDefault().VolumeFixProcent;
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPC.Take(1).FirstOrDefault().PolicyCompliant;
                    }
                    if (count2 == 2)
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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPC.Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant2 = FormulaVPC.Skip(1).Take(1).FirstOrDefault().PolicyCompliant;
                    }
                    if (count2 >= 3)
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
                        ViewBag.CurrrencyCode = CurrrencyCode;
                        ViewBag.UnitName = UnitName;
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Medium") { ViewBag.Mediumx = "X"; } else { ViewBag.Mediumx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "Low") { ViewBag.Lowx = "X"; } else { ViewBag.Lowx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "High") { ViewBag.Highx = "X"; } else { ViewBag.Highx = " "; }
                        if (FormulaVPC.Take(1).FirstOrDefault().Indicator == "UltraLow") { ViewBag.UltraLowx = "X"; } else { ViewBag.UltraLowx = " "; }
                        ViewBag.PolicyCompliant1 = FormulaVPC.Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant2 = FormulaVPC.Skip(1).Take(1).FirstOrDefault().PolicyCompliant;
                        ViewBag.PolicyCompliant3 = FormulaVPC.Skip(2).Take(1).FirstOrDefault().PolicyCompliant;
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
                ViewBag.CurrrencyCode = "null";
                ViewBag.UnitName = "null";
                ViewBag.raportname = "null";
                ViewBag.Mediumx = " ";
                ViewBag.Lowx = " ";
                ViewBag.Highx = " ";
                ViewBag.UltraLowx = " ";
                ViewBag.PolicyCompliant1 = "null";
                ViewBag.PolicyCompliant2 = "null";
                ViewBag.PolicyCompliant3 = "null";
            }
            return View();
        }
        public ActionResult ReportPDF(Keyfromlink input)
        {
            return new Rotativa.MVC.ActionAsPdf("GetReport");
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
        public string key { get; set; }
        public string code { get; set; }
    }
}