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
        Userdatabase db = new Userdatabase();

        [HttpGet]
        public ActionResult Index(Keyfromlink keyfromlink)
        {
            //var Keys = from p in Userdatabase.Keys select p;
            //model.Persons = persons.ToList();
            if (keyfromlink.Atribute.Equals(0))
            {
                ViewBag.Hepuhv = "Hepuhv0";
                ViewBag.Mepuhv = "Mepuhv0";
                ViewBag.Lepuhv = "Lepuhv0";
                ViewBag.Ulepuhv = "Ulepuhv0";
                ViewBag.Lpdrp = "Lpdrp0";
            }

            if (keyfromlink.Atribute.Equals(101))
            {
                ViewBag.Hepuhv = "Hepuhv101";
                ViewBag.Mepuhv = "Mepuhv101";
                ViewBag.Lepuhv = "Lepuhv101";
                ViewBag.Ulepuhv = "Ulepuhv101";
                ViewBag.Lpdrp = "Lpdrp101";
            }
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