using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQOverview
{
    public class AggregateFunction
    {
        public AggregateFunction()
        {
            var apple = new Product { Name = "Apple" };
            var orange = new Product { Name = "Orange" };
            var bread = new Product { Name = "Bread" };


            var customers = new[] {
                                    new Customer1 { Name = "Dana",
                                                    Orders = new[] {
                                                                    new Order { Product = apple, Quantity = 10 },
                                                                    new Order { Product = orange, Quantity = 5 } }.ToList() },
                                    new Customer1 { Name = "Arek",
                                                    Orders = new[] {
                                                                    new Order { Product = bread, Quantity = 5 },
                                                                    new Order { Product = orange, Quantity = 2 } }.ToList() },
                                    new Customer1 { Name = "Dima",
                                                    Orders = new[] {
                                                                    new Order { Product = apple, Quantity = 10 } }.ToList() }
                                   }.ToList();

            var query = from customer in customers
                        select new { Name = customer.Name, Orders = customer.Orders.Select(o => o.Product.Name).Aggregate((currentP, nextP) => { return currentP + ", " + nextP; }) };

            foreach(var custom in query)
            {
                Console.WriteLine($"Customer: {custom.Name}, Orders: {custom.Orders}");
            }

            var query1 = customers.Select(c =>
            {
                return new
                {
                    Name = c.Name,
                    Orders = string.Join(",", c.Orders.Select(o => o.Product.Name).ToArray())
                };
            });

            foreach (var custom in query1)
            {
                Console.WriteLine($"Customer: {custom.Name}, Orders: {custom.Orders}");
            }

        }
    }


    public class Customer1
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
    }
}
