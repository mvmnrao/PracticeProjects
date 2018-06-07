using FullStack.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.DataLayer
{
    public class SalesDataContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
