using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the amount before procceding")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }



        //to set as foreign key 
        [Required]
        public int CheckingAccountId { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set;}
    }

}