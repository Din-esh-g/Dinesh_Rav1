using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project6363.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Projecct1.Models.Bank
    {
        public interface IAccount
        {
            string type { get; set; }
            int accountNumber { get; set; }
            int CustomerId { get; set; }
            double InterestRate { get; set; }
            double Balance { get; set; }
            bool status { get; set; }
            int period { get; set; }
            DateTime dateAndTime { get; set; }


            //This method will add the new transaction in list

            // void addTransaction(Activities transactionNew);
            // withdraw transaction
            double withdraw(double amount);
            //deposit transaction
            double deposit(double amount);
            //for interest 
            double intrest(DateTime date);
        }
    }

}
