using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLib
{
    public abstract class AbstractClass
    {
        public int intPublic;

        public int intPublicProp { get; set; }

        public void PublicMedhod()
        { 
        
        }

        public abstract void CannotHaveDefinition()
        { 
        
        }

        private interface PrivateInterface
        {
            void TestMethod();
        }
    }
}
