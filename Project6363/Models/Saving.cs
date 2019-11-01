using Project6363.Models.Projecct1.Models.Bank;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project6363.Models
{
    public class Saving: IAccount
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Types")]
        public string type { get; set; }
        [Display(Name = "Account Number")]
        public int accountNumber { get; set; }
        [Display(Name = "CustomerId")]

        public int CustomerId { get; set; }
        [Display(Name = "interesrt Rate")]
        public double InterestRate { get; set; }
        [Display(Name = "Balance")]
        public double Balance { get; set; }
        [Display(Name = "Opening Date")]
        public DateTime createdAt { get; set; }
        [Display(Name = "Status")]
        public bool status { get; set; }
        [Display(Name = "Period")]
        public int period { get; set; }
        [Display(Name = "Date and Time")]
        public DateTime dateAndTime { get; set; }
        public Customer Customer { get; set; }




        public double withdraw(double amount)
        {
            amount = 0;
            this.Balance = this.Balance - amount;

            return Balance;
        }


        public double deposit(double amount)
        {

            this.Balance += amount;
            return Balance;


        }

        public double intrest(DateTime date)

        {
            double interest = 100;
            this.Balance += interest;
            return Balance;
        }
    }
}
