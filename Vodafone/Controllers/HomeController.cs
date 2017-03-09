﻿using System;
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
        private EnergyMarketPriceTestEntities db = new EnergyMarketPriceTestEntities();
        [HttpGet]
        public ViewResult Index(Keyfromlink keyfromlink)
        {
            //var keyid = db.Formulae.Where(p => p.PublicKey = keyfromlink).ToList().First().ID;
            var formulaid = 2357;
            //var formulaid = 562;
            ViewBag.High = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).ToList().First().High;
            ViewBag.Medium = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).ToList().First().Medium;
            ViewBag.Low = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).ToList().First().Low;
            ViewBag.MinMarket_Value = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).ToList().First().MinMarket_Value;
            ViewBag.MinMarket_Date = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).ToList().First().MinMarket_Date;
            ViewBag.VolumeTotal = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).ToList().First().VolumeTotal;
            ViewBag.MaxPriceFixed = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).Take(1).First().MaxPriceFixed;
            ViewBag.MaxPriceFixed1 = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).Skip(1).Take(1).First().MaxPriceFixed;
            ViewBag.MaxPriceFixed2 = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).Skip(2).Take(1).First().MaxPriceFixed;
            ViewBag.VolumeFixProcent = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).Take(1).First().VolumeFixProcent;
            ViewBag.VolumeFixProcent1 = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).Skip(1).Take(1).First().VolumeFixProcent;
            ViewBag.VolumeFixProcent2 = db.fnFormulaVPC(formulaid).OrderByDescending(p => p.Year).Skip(2).Take(1).First().VolumeFixProcent;
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
        public int Atribute { get; set; }
    }
}