using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    public class Writer<T> where T : IWriteTo
    {
        private T writeTo;

        public Writer(T _writeTo)
        {
            writeTo = _writeTo;
        }

        public void WriteMessage(string message)
        {
             ((IWriteTo)writeTo).Write(message);
        }
    }
}
