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
        [HttpGet]
        public ActionResult Index(Keyfromlink keyfromlink)
        {
            if (ModelState.IsValid) {
                if (ValidateUserKeys(Model.Ids))
            }
            IEnumerable<UserKeys> keyfromlink.Atribute
            ViewBag.Hepuhv = keyfromlink.Atribute;
            ViewBag.Mepuhv = "Mepuhv";
            ViewBag.Lepuhv = "Lepuhv";
            ViewBag.Ulepuhv = "Ulepuhv";
            ViewBag.Lpdrp = "Lpdrp";
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