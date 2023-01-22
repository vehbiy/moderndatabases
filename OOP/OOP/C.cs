using System;

namespace OOP
{
    public class C : B
    {
        public int Id
        {
            get;
            set;
        }

        public C(string name, string surname, int id) : base(name, surname)
        {
            Console.WriteLine("C 3 parametered constructor");
            this.Id = id;
        }

        public void Test()
        {
            Console.WriteLine("Test C");
        }
    }
}