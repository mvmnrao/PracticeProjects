using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSampleCastleWindsor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application has started..");

            var container = new WindsorContainer();
            container.Register(Component.For<ICompositionRoot>().ImplementedBy<CompositionRoot>());
            container.Register(Component.For<IConsoleWriter>().ImplementedBy<ConsoleWriter>());

            // This line is not a mistake.  Its intent is to contrast 
            // registering a component as Transient vs. Singleton.
            //
            // The prior example registered this type as a singleton,
            // now we're registering this type as a Transient so the 
            // output will show that new instances of ISingletonDemo are
            // created each time the dependency is fulfilled.
            container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>().LifestyleTransient());

            ICompositionRoot composit = container.Resolve<ICompositionRoot>();

            composit.LogMessage("Hello Manik");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
