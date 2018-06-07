using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSampleCastleWindsor
{
    class CompositionRoot : ICompositionRoot
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly ISingletonDemo _singletonDemo;

        public CompositionRoot(IConsoleWriter consoleWriter, ISingletonDemo singletonDemo)
        {
            this._consoleWriter = consoleWriter;
            this._singletonDemo = singletonDemo;
            _consoleWriter.LogMessage("This is from CompositionRoot constructor.");
        }

        public void LogMessage(string text)
        {
            _consoleWriter.LogMessage($"CompositionRoot.LogMessage - SingletonDemo object Guid is: {_singletonDemo.ObjectId}");
            _consoleWriter.LogMessage(text);
        }
    }
}
