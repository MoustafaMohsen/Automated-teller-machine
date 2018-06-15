namespace AutomatedTellerMachine.Migrations
{
    using AutomatedTellerMachine.Models;
    using AutomatedTellerMachine.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutomatedTellerMachine.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AutomatedTellerMachine.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if(!context.Users.Any(t=>t.UserName == "admin@mvctm.com"))
            {
                //23/2
                //create a new user
                var adminUser = new ApplicationUser {UserName= "admin@mvctm.com",Email= "admin@mvctm.com" };
                userManager.Create(adminUser,password:"12345sC@");

                // the new user to checking account
                var service =new CheckingAccountService(context);
                service.CreateCheckingAccount("admin","user",adminUser.Id,1000);

                //adding a role to the database
                context.Roles.AddOrUpdate(r=>r.Name,new IdentityRole { Name="Admin"});
                context.SaveChanges();

                //adding a the role to the admin user
                userManager.AddToRole(userId:adminUser.Id,role:"Admin");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
