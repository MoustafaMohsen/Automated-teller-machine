using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Services
{
    public class CheckingAccountService
    {

        //To pass the Dbcontext to the db variable when calling the service
        private ApplicationDbContext db;
        public CheckingAccountService(ApplicationDbContext dbContext) {
            db = dbContext;
        }

        //to create a checking account using the instance with dbcontext just write
        public void CreateCheckingAccount (string firstName,string lastName,string userId,decimal initialBalance)
        {
            var accountNumber = (123456 + db.CheckingAccounts.Count()).ToString().PadLeft(10, '0');

            var checkingAccount = new CheckingAccount
            {
                FirstName = firstName,
                LastName = lastName,
                AccountNumber = accountNumber,
                Balance = initialBalance,
                ApplicationUserId = userId
            };

            db.CheckingAccounts.Add(checkingAccount);
            db.SaveChanges();

        }
        //to create a checking account using the instance with dbcontext. just pass the instance 
        //with dbcontext and call the createchekingAccount method with 

    }
}