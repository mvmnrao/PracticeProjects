using FullStack.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.EntityFrameworkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            GetCustomers();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void GetCustomers()
        {
            using (var context = new SalesDataContext())
            {
                var customers = context.Customers.ToList();

                foreach(var c in customers)
                {
                    Console.WriteLine(c.FirstName);
                }
            }
        }
    }
}
