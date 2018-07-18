using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSub
{
    class Class1
    {
        public Class1()
        {
            var apple = new Product { Name = "Apple" };
            var orange = new Product { Name = "Orange" };
            var bread = new Product { Name = "Bread" };


            var customers = new[] {
    new Customer { Name = "Dana", Orders = new[] { new Order { Product = apple, Quantity = 10 }, new Order { Product = orange, Quantity = 5 } }.ToList() },
    new Customer { Name = "Arek", Orders = new[] { new Order { Product = bread, Quantity = 5 }, new Order { Product = orange, Quantity = 2 } }.ToList() },
    new Customer { Name = "Dima", Orders = new[] { new Order { Product = apple, Quantity = 10 } }.ToList() }
}.ToList();



        }

    }
}
