using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQOverview
{
    public class GroupByClause
    {
        public GroupByClause()
        {
            List<int> numbers = new List<int>() { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };

            IEnumerable<IGrouping<int, int>> query = from number in numbers
                                                     group number by number % 2;

            IEnumerable<int> query1 = from number in numbers
                                      where number % 2 == 0
                                      select number;
            //If we add break point before foreach and try to check value of query or query1 in Quick View, it will automatically trigger enumberation and get results. Hence the differed execution is done before foreach.

            foreach (var group in query)
            {
                Console.WriteLine(group.Key == 0 ? $"Event Number:" : $"Odd Number:");

                foreach(var num in group)
                {
                    Console.WriteLine(num);
                }
            }

            foreach(var number in query1)
            {
                Console.WriteLine($"Event Number: {number}");
            }

            List<Student> students = new List<Student> {
                                                        new Student { Year = 2010, FirstName = "Manik", LastName = "M"},
                                                        new Student{ Year = 2011, FirstName = "Prasad", LastName = "M"},
                                                        new Student{ Year = 2010, FirstName = "Prabhu", LastName = "Kolla" },
                                                        new Student{ Year = 2010, FirstName = "Mahesh", LastName = "M"},
                                                        new Student{ Year = 2011, FirstName = "Pramod", LastName = "Aleti"}};

            var nestedGroupQuery = from student in students
                                   group student by student.Year into groupOne
                                   from grpOne in (from student in groupOne
                                                   group student by student.LastName)
                                   group grpOne by groupOne.Key;

            // Three nested foreach loops are required to iterate  
            // over all elements of a grouped group. Hover the mouse  
            // cursor over the iteration variables to see their actual type. 
            foreach (var outerGroup in nestedGroupQuery)
            {
                Console.WriteLine("DataClass.Student Level = {0}", outerGroup.Key);
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine("\tNames that begin with: {0}", innerGroup.Key);
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine("\t\t{0} {1}", innerGroupElement.LastName, innerGroupElement.FirstName);
                    }
                }
            }

            var groupQuery = from student in students
                             group student by student.Year into groupOne
                             select groupOne;

            foreach(var group in groupQuery)
            {
                Console.WriteLine($"Group Key: {group.Key}");
                
                foreach(var student in group)
                {
                    Console.WriteLine($"Year: {student.Year}, Name: {student.FirstName} {student.LastName}");
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine("==============================================");
            Console.WriteLine(" ");            
        }

        private class Student
        {
            public int Year { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
