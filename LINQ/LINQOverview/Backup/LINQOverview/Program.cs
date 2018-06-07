using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;

namespace LINQOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            //NumQuery();
            //ObjectQuery();
            //ObjectQueryForXML();
            //XMLQuery();
            //CreateCustomersFrmXML();
            //ObjectQueryForXMLElem();
            //XMLQueryNew();
            ObjectQueryTable();

            Console.ReadKey();
        }

#region "LINQToObject"

        static void NumQuery()
        {
            int[] numbers = new int[] { 1, 4, 9, 16, 25, 36 };

            var evenNumbers = from p in numbers 
                                where (p % 2) == 0 select p;

            Console.WriteLine("Result:");

            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }
        }

        static void ObjectQuery()
        {
            var results = from c in CreateCustomers()
                          where c.City == "London" && c.CustomerID == "CONSH"
                          select c;
            foreach (Customer c in results)
            {
                Console.WriteLine("Customer ID: " + c.CustomerID.ToString() + " City: " + c.City);
            }
        }

        static IEnumerable<Customer> CreateCustomers()
        {
            return new List<Customer>
            {
                new Customer { CustomerID = "ALFKI", City = "Berlin" },
                new Customer { CustomerID = "BONAP", City = "Marseille" },
                new Customer { CustomerID = "CONSH", City = "London" },
                new Customer { CustomerID = "EASTC", City = "London" },
                new Customer { CustomerID = "FRANS", City = "Torino" },
                new Customer { CustomerID = "LONEP", City = "Portland" },
                new Customer { CustomerID = "NORTS", City = "London" },
                new Customer { CustomerID = "THEBI", City = "Portland" }
            };
        }

#endregion "LINQToObject"

#region "LINQToXML"

        static void ObjectQueryForXML()
        {
            var results = from c in CreateCustomersFrmXML()
                          where c.CustomerID == "EASTC" //c.City == "London"
                          select c;
            foreach (Customer c in results)
            {
                Console.WriteLine("Customer ID: " + c.CustomerID.ToString() + " City: " + c.City);
            }
        }

        static IEnumerable<Customer> CreateCustomersFrmXML()
        {
            return from c in XDocument.Load("Customers.xml").Descendants("Customers").Descendants()
                   select new Customer
                   {
                       City = c.Attribute("City").Value,
                       CustomerID = c.Attribute("CustomerID").Value
                   };

            //var doc = XDocument.Load("Customers.xml");
            //var results = from c in doc.Descendants("Customers").Descendants()
            //              where c.Attribute("City").Value == "London"
            //              select c;

            //foreach (var con in results)
            //{
            //    Console.WriteLine(con);
            //}
        }

        static void ObjectQueryForXMLElem()
        {
            var results = from c in CreateCustomersFrmXMLElem()
                          where c.CustomerID == "EASTC" //c.City == "London"
                          select c;
            foreach (Customer c in results)
            {
                Console.WriteLine("Customer ID: " + c.CustomerID.ToString() + " City: " + c.City);
            }
        }

        static IEnumerable<Customer> CreateCustomersFrmXMLElem()
        {
            return from c in XDocument.Load("Customers.xml").Elements("Customers").Elements("Customer")
                   select new Customer
                   {
                       City = c.Attribute("City").Value,
                       CustomerID = c.Attribute("CustomerID").Value
                   };
        }

        public static void XMLQuery()
        {
            var doc = XDocument.Load("Customers.xml");
            Console.WriteLine("XML Document:\n{0}", doc);
        }

        public static void XMLQueryNew()
        {
            XDocument doc = XDocument.Load("Customers.xml");
            var results = from c in doc.Descendants("Customers").Descendants()
                          where c.Attribute("City").Value == "London"
                          select c;

            XElement transformedResults =
            new XElement("Londoners",
            from customer in results
            select new XElement("Contact",
            new XAttribute("ID", customer.Attribute("CustomerID").Value),
            new XElement("City", customer.Attribute("City").Value)));

            transformedResults.Save("transformedCustomers.xml");
            Console.WriteLine("Results:\n{0}", transformedResults);
        }

#endregion "LINQToXML"

#region "LINQToDataSet"

        static void ObjectQueryTable()
        {
            var results = from c in GetDataTable()
                          where c.City == "London"
                          select c;
            foreach (var c in results)
                Console.WriteLine("{0}\t{1}", c.CustomerID, c.City);

            //foreach (DataRow dr in GetDataTable().Rows)
            //{
            //    Console.WriteLine(dr[0].ToString());
            //}
        }

        static DataSet.CustomersDataTable GetDataTable()
        {
            DataSet.CustomersDataTable tbl = new DataSet.CustomersDataTable();

            //tbl.Columns.Add("CustomerID", typeof(string));
            //tbl.Columns.Add("Name", typeof(string));
            //tbl.Columns.Add("City", typeof(string));

            tbl.Rows.Add("1001", "Berlin", "Berlin");
            tbl.Rows.Add("1002", "BONAP", "Marseille");
            tbl.Rows.Add("1003", "CONSH", "London");
            tbl.Rows.Add("1004", "EASTC", "London");
            tbl.Rows.Add("1005", "FRANS", "Torino");
            tbl.Rows.Add("1006", "LONEP", "Portland");
            tbl.Rows.Add("1007", "NORTS", "London");
            tbl.Rows.Add("1008", "THEBI", "Portland");

            return tbl;
        }

#endregion
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return CustomerID + "\t" + City;
        }
    }
}
