using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        //the view part
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Transaction/Deposit
        public ActionResult Deposit(int checkingAccountId)
        {

            return View();
        }

        //the reciver part
        [HttpPost]
        public ActionResult Deposit(Transaction transactions)
        {
            if (ModelState.IsValid)
            {
                //save To database
                db.Transactions.Add(transactions);
                db.SaveChanges();
                return RedirectToAction("index","Home");
            }
            return View();
        }


    }
}
