using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Application has started..");

            //**************************ActionFuncPredicateConverterComparision********************
            Console.WriteLine("***************ActionFuncPredicateConverterComparision***************");
            ActFuncPredicate actFuncPred = new ActFuncPredicate();
            actFuncPred.AddAndDisplay(2, 3);

            actFuncPred.GreetingMessage("Manik", 33, actFuncPred.FirstFunction);
            actFuncPred.GreetingMessage("Manik", 100000, actFuncPred.SecondFunction);

            actFuncPred.GetEmployeeOlderThan30();
            actFuncPred.GetEmployeeOlderThan33();

            actFuncPred.TransformToList();

            actFuncPred.OrderByName();
            Console.WriteLine("***************End ActionFuncPredicateConverterComparision***************");
            //**************************End ActionFuncPredicateConverterComparision********************

            //**************************Tuple***************************************

            Tuples myTuples = new Tuples();
            myTuples.MyTuple = myTuples.ReturnTuple();

            Console.WriteLine(myTuples.MyTuple.Item1);
            Console.WriteLine(myTuples.MyTuple.Item2);
            Console.WriteLine(myTuples.MyTuple.Item3.Name);


            myTuples.SortTupleAndDictionary();
            //**************************End Tuple***************************************


            //*************************Stream*********************************************

            MyStream myS = new MyStream();
            myS.ReadStreamLineByLine();
            //************************ End Stream***********************************

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
