using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Training_1.Task_1
{
    public struct Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        private int _age;
        public int Age
        {
            get => _age;
            set => _age = value > 0 ?  value 
                : throw new ArgumentException("Age must be bigger than 0");
        }

        public string OlderThan(int n)
        {
            if(Age == n)
            {
                return $"{FirstName} {LastName} same as {n}";
            }
            return _age > n ? $"{FirstName} {LastName} older than {n}"
                : $"{FirstName} {LastName} younger than {n}";
        }

        public string OlderThan(Person person)
        {
            return OlderThan(person.Age);
        }
    }
}
