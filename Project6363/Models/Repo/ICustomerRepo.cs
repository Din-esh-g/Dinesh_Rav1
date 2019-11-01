using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project6363.Models.Repo
{
   public interface ICustomerRepo
    {
     
            Task<Customer> Get(int? id);
            Task<List<Customer>> Get();
            Task<bool> Create(Customer customer);
            Task<bool> Edit(int id, Customer customer);
            Task<bool> Delete(int id);
            bool CustomerExists(int id);

        }
    

}
