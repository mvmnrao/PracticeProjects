using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class ActFuncPredicate
    {

        public delegate void myDel(string s);


        //***************************Action<TParameter>***************************************************
        public void Add(int a, int b, Action<string> writeToConsole)
        {
            var c = a + b;
            writeToConsole(c.ToString());
        }

        public void AddAndDisplay(int a, int b)
        {
            this.Add(a, b, (message) =>
            {
                Console.WriteLine($"Sum of {a} and {b} is: {message}");
            });
        }

        //***************************Func<TParameter, TOutput>***************************************************

        public void GreetingMessage(string name, int property, Func<string, int, string> funcDel)
        {
            Console.WriteLine(funcDel(name, property));
        }

        public string FirstFunction(string name, int age)
        {
            return $"Hello {name}, you are now {age} old.";
        }

        public string SecondFunction(string name, int salary)
        {
            return $"Hello {name}, you are drawing {salary} rupees salary per month";
        }

        //***************************Predicate<in T>***************************************************

        public void GetEmployeeOlderThan30()
        {
            Employee[] employees = (new Employee[3] {
                new Employee {Name= "Manik", Age = 33 },
                new Employee {Name= "Mahesh", Age = 30 },
                new Employee {Name= "Mohan", Age = 35 }
            });

            Employee finalEmployee = Array.Find(employees, (emp) => {
                return emp.Age > 30;
            });

            Console.WriteLine($"{finalEmployee.Name} is of {finalEmployee.Age} years old.");

        }

        public void GetEmployeeOlderThan33()
        {
            List<Employee> employees = new List<Employee> {
                new Employee {Name= "Manik", Age = 33 },
                new Employee {Name= "Mahesh", Age = 30 },
                new Employee {Name= "Mohan", Age = 35 }
            };

            Employee finalEmployee = employees.Find((emp) => {
                return emp.Age > 33;
            });

            Console.WriteLine($"{finalEmployee.Name} is of {finalEmployee.Age} years old.");

        }

        //***************************Converter<TInput, TOutput>***************************************************

        public void TransformToList()
        {
            Employee[] employeeArr = (new Employee[3] {
                new Employee {Name= "Manik", Age = 33 },
                new Employee {Name= "Mahesh", Age = 30 },
                new Employee {Name= "Mohan", Age = 35 }
            });

            EmployeeX[] employeeList;

            employeeList = Array.ConvertAll<Employee, EmployeeX>(employeeArr, ConverterDel);

            employeeList.ToList().ForEach((emp) => {
                Console.WriteLine($"Your name is {emp.Name} and Age is {emp.Age}");
            });

        }

        public EmployeeX ConverterDel(Employee emp)
        {
            return new EmployeeX() { Name = emp.Name, Age = emp.Age };            
        }

        //***************************Comparison<T>***************************************************

        public void OrderByName()
        {
            Employee[] employeeArr = (new Employee[3] {
                new Employee {Name= "Manik", Age = 33 },
                new Employee {Name= "Mahesh", Age = 30 },
                new Employee {Name= "Mohan", Age = 35 }
            });

            Array.Sort(employeeArr, SortFunction);

            Console.WriteLine("Array sort by Name:");

            employeeArr.ToList().ForEach((emp) =>
            {
                Console.WriteLine(emp.Name);
            });

        }

        public int SortFunction(Employee emp1, Employee emp2)
        {
            return emp1.Name.CompareTo(emp2.Name);
        }

        //******************************************************************************

    }

    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class EmployeeX
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
