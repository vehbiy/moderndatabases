using System;
namespace OOP
{
    public class A
    {
        public string Name
        {
            get;
            set;
        }

        public A()
        {
            Console.WriteLine("A parameterless constructor");
        }

        public A(string name)
		{
            Console.WriteLine("A paremetered constructor");
            this.Name = name;
		}

        public void Test()
        {
            Console.WriteLine("Test A");
        }
    }
}
