using Microsoft.EntityFrameworkCore;

using Project6363.Models;


namespace Project6363.Models
{
    public class BankDbContext: DbContext
    {


        public BankDbContext(DbContextOptions<BankDbContext> context)
              : base(context)
        {

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=Project1;integrated security=True;MultipleActiveResultSets=True;");
            }
        }

      
        public DbSet<Customer> Customer { get; set; }

      
        public DbSet<Project6363.Models.Business> Business { get; set; }

      
        public DbSet<Project6363.Models.Saving> Saving { get; set; }



    }
}
