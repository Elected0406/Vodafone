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
        private EMPModel db = new EMPModel();
        [HttpGet]
        public ViewResult Index(Keyfromlink keyfromlink)
        {
            var vwfvpc1 = 562;
            var sql2 = ("SELECT Id,Formula,Year,") +
            ("ROUND(cast(SumMarket_Value as numeric(15,2)), 2) as SumMarket_Value,") +
            ("ROUND(cast(StdevMarket_Value as numeric(15,2)), 2) as StdevMarket_Value,") +
            ("ROUND(cast(AnualMarket_Value as numeric(15,2)), 2) as AnualMarket_Value,") +
            ("ROUND(cast(MaxPriceFixed as numeric(15,2)), 2) as MaxPriceFixed,") +
            ("ROUND(cast(VolumeFixProcent as numeric(15,2)), 2) as VolumeFixProcent,") +
            ("ROUND(cast(VolumeTotal as numeric(15,2)), 2) as VolumeTotal, ") +
            ("Indicator,") +
            ("ROUND(cast(MinMarket_Date as numeric(15,2)), 2) as MinMarket_Date, ") +
            ("ROUND(cast(MinMarket_Value as numeric(15,2)), 2) as MinMarket_Value, ") +
            ("ROUND(cast(High as numeric(15,2)), 2) as High, ") +
            ("ROUND(cast(Medium as numeric(15,2)), 2) as Medium,  ") +
            ("ROUND(cast(Low as numeric(15,2)), 2) as Low ") +
            ("FROM vwFormulaVPC WHERE Formula =") + vwfvpc1 +
            ("order by [Year] desc");
            var vwfvpc2 = db.vwFormulaVPC.SqlQuery(sql2).ToList();
            return View(vwfvpc2);
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