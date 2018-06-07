using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSampleCastleWindsor
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly ISingletonDemo _singletonDemo;

        public ConsoleWriter(ISingletonDemo singletonDemo)
        {
            _singletonDemo = singletonDemo;
        }

        public void LogMessage(string text)
        {
            Console.WriteLine($"ConsoleWriter.LogMessage - SingletonDemo object Guid: {_singletonDemo.ObjectId}");
            Console.WriteLine(text);
        }
    }
}
