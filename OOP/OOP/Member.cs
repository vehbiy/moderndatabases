using System;
namespace OOP
{
    public class Member
    {
		public static string Intro
		{
			get;
			set;
		}

        public string Name
        {
            get;
            set;
        }
		public string Surname
		{
			get;
			set;
		}
		public int Id
		{
			get;
			set;
		}

        public Member()
        {
            Console.WriteLine("Member default constructor");
        }

        public Member(string name, string surname, int id)
		{
            this.Name = name;
            Surname = surname;
            this.Id = id;
            Console.WriteLine("Member 3 parameter constructor");
		}

        public Member(string name, string surname) : this(name, surname, 0)
		{
            Console.WriteLine("Member 2 parameter constructor");
		}

        public void Test()
        {
            Console.WriteLine("Test");
        }

        static Member()
        {
			Intro = "intro";
			Member.Intro = "intro";

            StaticTest();
        }

        public static void StaticTest()
        {
            
        }
    }
}
