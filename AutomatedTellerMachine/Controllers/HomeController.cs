using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        //Mycode
        public ActionResult Index()
        {
            
          var userID = User.Identity.GetUserId();
          var CHID = db.CheckingAccounts.Where(c=> c.ApplicationUserId == userID ).First().Id;

          ViewBag.CAId = CHID;

            //pin Viewbag
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId:userID);

            ViewBag.Pin=user.Pin;
            //return PartialView(); //view withoutvlayout 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Your contact page.";
            return View();
        }
        [HttpPost]
        //Mycode
        public ActionResult Contact(string message)
        {
            //TODO : Send message to HQ
            ViewBag.TheMessage = "We got ur Message";
            return View();
        }
        //Mycode
        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if(letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            return Content(serial);
        }


        //TEsting post 23/2
        public ActionResult Show() {
            ViewBag.Name="Blank";
            return View();
        }
        //post
        [HttpPost]
        public ActionResult Show(string input)
        {
            ViewBag.Name = "thanks";
            return View();
        }
    }
}