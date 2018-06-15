using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        //[RegularExpression(@"\d{6,10}",ErrorMessage ="This field Must be between 6 and 10 digits")]
        [Display(Name = "Account #")]
        public string AccountNumber { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }


        //Getter
    public string Name
    {
        get
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
   
        //Review reunderstand 18/2
        public virtual ApplicationUser User { get; set; }


        //asp.net is smart enough to knnow that ApplicationUserId is from the Id of User in ApplicationUser
        public string ApplicationUserId { get; set; }

        //end review


        //challange 20/2
        public virtual ICollection<Transaction> Transactions {get; set;}
        
    }
}