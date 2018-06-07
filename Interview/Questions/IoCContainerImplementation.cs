using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    public interface IoCInterface
    {
        int Count { get; set; }
        string Name { get; set; }
    }

    public class IoCContainerImplementation : IoCInterface
    {
        public int Count { get ; set ; }
        public string Name { get; set; }

        public IoCContainerImplementation(int count, string name)
        {
            Count = count;
            Name = name;
        }

        public class IoCClass : IoCInterface
        {
            public int Count { get; set; }
            public string Name { get; set; }

            private IoCInterface _iocClassObj;

            public IoCClass(IoCInterface iocInstance)
            {
                _iocClassObj = iocInstance;
                Count = _iocClassObj.Count;
                Name = _iocClassObj.Name;
            }
        }

        public class IoCClassOne : IoCInterface
        {
            public int Count { get; set; }
            public string Name { get; set; }

            public IoCClassOne()
            {
                Count = 11;
                Name = "Mahesh";
            }
        }

        public class IoCClassTwo : IoCInterface
        {
            public int Count { get; set; }
            public string Name { get; set; }

            public IoCClassTwo()
            {
                Count = 11;
                Name = "Mohan";
            }
        }
    }


}
