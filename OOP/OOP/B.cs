using System;

namespace OOP
{
    public class B : A
    {
        public string Surname
        {
            get;
            set;
        }

        public B()
        {
            Console.WriteLine("B parameterless constructor");
        }

        public B(string name, string surname) : base(name)
        {
            Console.WriteLine("B 2 parametered constructor");
            this.Surname = surname;
        }

        public void Test()
        {
            Console.WriteLine("Test B");
        }
    }
}