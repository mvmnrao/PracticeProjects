using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    class CompareToLearn
    {
        public CompareToLearn()
        {
            Console.WriteLine();
            Console.WriteLine("CompareTo Begin");
        }

        public void Execute()
        {
            String a = "TechBeamers";
            String b = "TECHBEAMERS";
            int c;
            c = a.CompareTo(b);
            Console.WriteLine(c);

            MyClass c1 = new MyClass() { Name = "Manik", Salary = 2000000 };
            MyClass c2 = new MyClass { Name = "Mahesh", Salary = 2100000 };

            int d = c1.CompareTo(c2);
            Console.WriteLine(d);
        }

        ~CompareToLearn()
        {
            Console.WriteLine("CompareTo End");
            System.Threading.Thread.Sleep(1000);
        }
    }

    class MyClass : IComparable
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public int CompareTo(object obj)
        {
            if(Name == ((MyClass)obj).Name && Salary == ((MyClass)obj).Salary)
            {
                return 1;
            }
            return 0;
        }
    }
}
