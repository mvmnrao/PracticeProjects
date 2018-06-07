using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKeyWord
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new B();

            a.M1();
            a.M2();
            a.M3();

            B b = new B();
            b.M1();
            b.M2();
            b.M3();

            //B b1 = new A() as B;
            //b1.M1();  //Exception
            //b1.M2();
            //b1.M3();

            Console.ReadKey();
        }

    }

    class A
    {
        public virtual void M1()
        {
            Console.WriteLine("I am A - M1");
        }
        public void M2()
        {
            Console.WriteLine("I am A - M2");
        }

        public void M3()
        {
            Console.WriteLine("I am A - M3");
        }
    }

    class B : A
    {
        public override void M1()
        {
            Console.WriteLine("I am B - M1");
        }

        public void M2()
        {
            Console.WriteLine("I am B - M2");
        }

        public new void M3()
        {
            Console.WriteLine("I am B - M3");
        }
    }
}
