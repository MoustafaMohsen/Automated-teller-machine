using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
namespace AutomatedTellerMachine.Controllers
{
    public class CheckingAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CheckingAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckingAccount/Details/5
        public ActionResult Details()
        {
            //review 21/2
            var userId =User.Identity.GetUserId();
            var checkingAccount = db.CheckingAccounts.Where(c=>c.ApplicationUserId == userId).First();
            //review 21/2

            return View(checkingAccount);
        }
        //Details for admin
        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            //review 21/2
            var userId = User.Identity.GetUserId();
            //.Where()==>.Find(id)
            var checkingAccount = db.CheckingAccounts.Where(c => c.ApplicationUserId == id.ToString()).First();
            //review 21/2

            return View("Details",checkingAccount);
        }
        [Authorize(Roles = "Admin")]
        //Get:List
        public ActionResult List()
        {
            return View(db.CheckingAccounts.ToList());
        }        // GET: CheckingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckingAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
