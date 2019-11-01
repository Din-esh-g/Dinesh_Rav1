using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Project6363.Models.Repo
{
    public class BankRepo: ICustomerRepo
    {
        private BankDbContext _context;

        public BankRepo(BankDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<Customer> Get(int? id)
        {
            var customer = await _context.Customer
               .FirstOrDefaultAsync(m => m.Id == id);

            return customer;
        }

        public async Task<List<Customer>> Get()
        {
            var customers = await _context.Customer.ToListAsync();
            return customers;
        }

        public async Task<bool> Create(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Edit(int id, Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var customer = await this.Get((int?)id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }

    }


}

