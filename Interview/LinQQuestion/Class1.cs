using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQQuestion
{
    class Class1
    {
        void Main()
        {
            var people = new Dictionary<Person, Preferences>() {
                                                                { new Person("John", "Smith"), new Preferences("johny88") },
                                                                { new Person("Alice", "Jones") , new Preferences("alice7")},
                                                                };

            var alicePreferences = people[new Person("Alice", "Jones")];
            Console.WriteLine(alicePreferences.Nickname);
        }
    }

    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }

    public class Preferences
    {
        public Preferences(string nickname)
        {
            Nickname = nickname;
        }

        public string Nickname { get; }
    }
}
