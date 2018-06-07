using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Questions.IoCContainerImplementation;

namespace Questions
{
    class Program
    {
        static void Main(string[] args)
        {
            MathRound mr = new MathRound();
            mr.Execute();

            DynamicAndByte db = new DynamicAndByte();
            db.Execute();

            CompareToLearn ctl = new CompareToLearn();
            ctl.Execute();

            ConstructorAndDistructor cad = new ConstructorAndDistructor();

            StaticMethod.Execute();

            DoubleFloatDecimal dfd = new DoubleFloatDecimal();
            dfd.Execute();

            // Index out of range exception.
            //int[] i = new int[0];
            //Console.WriteLine(i[0]);

            Console.WriteLine("---- IOC Container ----");

            var container = new WindsorContainer();

            container.Register(Component.For<IoCInterface>()
                                        .Named("One.base")
                                        .UsingFactoryMethod(kernel => new IoCContainerImplementation(10, "Manik")));
                                        //.ImplementedBy<IoCContainerImplementation>()
                                        //.DependsOn((kernel, parameters) =>
                                        //{
                                        //    parameters["count"] = 10;
                                        //    parameters["name"] = "Manik";
                                        //}));

            container.Register(Component.For<IoCInterface>()
                                        .ImplementedBy<IoCClass>()
                                        .Named("One")
                                        .DependsOn(Dependency.OnComponent(typeof(IoCContainerImplementation), "One.base")));

            container.Register(Component.For<IoCInterface>()
                                        .ImplementedBy<IoCClassOne>().Named("One.One"));
            container.Register(Component.For<IoCInterface>()
                                        .ImplementedBy<IoCClassTwo>().Named("One.Two"));

            var oneBase = container.Resolve<IoCInterface>("One.base");
            var one = container.Resolve<IoCInterface>("One");
            var oneOne = container.Resolve<IoCInterface>("One.One");
            var oneTwo = container.Resolve<IoCInterface>("One.Two");

            Console.WriteLine($"Count: {oneBase.Count.ToString()}, Name: {oneBase.Name}");
            Console.WriteLine($"Count: {one.Count.ToString()}, Name: {one.Name}");
            Console.WriteLine($"Count: {oneOne.Count.ToString()}, Name: {oneOne.Name}");
            Console.WriteLine($"Count: {oneTwo.Count.ToString()}, Name: {oneTwo.Name}");

            Console.ReadKey();
        }
    }
}
