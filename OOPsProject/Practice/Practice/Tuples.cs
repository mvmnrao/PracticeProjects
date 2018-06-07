using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Tuples
    {
        public Tuple<int, string, CustomeObj> MyTuple { get; set; }

        public Tuple<int, string, CustomeObj> ReturnTuple()
        {
            //return Tuple.Create<int, string, CustomeObj>(10, "Test message", new CustomeObj() { ID = 10, Name = "Manik" });

            return new Tuple<int, string, CustomeObj>(10, "Test message", new CustomeObj() { ID = 10, Name = "Manik" });

        }

        List<Tuple<int, string>> lista = new List<Tuple<int, string>>();
        List<Tuple<int, string>> listb = new List<Tuple<int, string>>();
        Dictionary<int, string> dict = new Dictionary<int, string>();

        public void SortTupleAndDictionary()
        {

            lista.Add(Tuple.Create(7, "Tânia"));
            lista.Add(Tuple.Create(2, "Rúbia"));
            lista.Add(Tuple.Create(4, "Samanta"));
            lista.Add(Tuple.Create(1, "Frederico"));
            lista.Add(Tuple.Create(3, "João"));
            lista.Add(Tuple.Create(5, "Carlos"));
            lista.Add(Tuple.Create(4, "Samanta"));
            lista.Add(Tuple.Create(8, "Marcio"));
            lista.Add(Tuple.Create(9, "Carla"));
            lista.Add(Tuple.Create(10, "Francisco"));

            Console.WriteLine("-------List A:------ Sort");
            lista.Sort((t1, t2) => { return t1.Item2.CompareTo(t2.Item2); });

            lista.ForEach((tup) => {
                Console.WriteLine(tup.Item1 + "- " + tup.Item2);
            });

            listb.Add(Tuple.Create(7, "Tânia"));
            listb.Add(Tuple.Create(2, "Rúbia"));
            listb.Add(Tuple.Create(4, "Samanta"));
            listb.Add(Tuple.Create(1, "Frederico"));
            listb.Add(Tuple.Create(3, "João"));
            listb.Add(Tuple.Create(5, "Carlos"));
            listb.Add(Tuple.Create(4, "Samanta"));
            listb.Add(Tuple.Create(8, "Marcio"));
            listb.Add(Tuple.Create(9, "Carla"));
            listb.Add(Tuple.Create(10, "Francisco"));

            Console.WriteLine("------List B:------ OrderBy");
            listb.OrderBy((tup) => {
                return tup.Item2;
            }).Select(tup => tup).ToList().ForEach((tup) =>
            {
                Console.WriteLine(tup.Item1 + "- " + tup.Item2);
            });

            dict.Add( 7, "Tania" );
            dict.Add(2, "Rúbia");
            dict.Add(4, "Samanta");
            dict.Add(1, "Frederico");
            dict.Add(3, "João");
            dict.Add(5, "Carlos");
            //dict.Add(4, "Samanta");
            dict.Add(8, "Marcio");
            dict.Add(9, "Carla");
            dict.Add(10, "Francisco");

            Console.WriteLine("------Dictionary:--------OrderBy");
            dict.OrderBy((dic) => dic.Value).Select(d => d).ToList().ForEach((d) => {
                Console.WriteLine(d.Key + "- " + d.Value);
            });

        }

    }

    class CustomeObj
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
