using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExamples
{
    public class Duck
    {
        public virtual void Swim()
        {
            //Swim....
        }
    }

    public class PlasticDuck: Duck
    {
        public bool IsTurnedOn { get; set; }

        public override void Swim()
        {
            if(!IsTurnedOn)
            {
                IsTurnedOn = true;
            }
            //Swim....
        }
    }

    public class Client
    {
        public void Swim(Duck duck)
        {
            duck.Swim();
        }
    }
}
