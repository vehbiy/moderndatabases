using System;

namespace OOP
{
    public class Manager : Employee
    {
        public override void SendReport()
        {
            Console.WriteLine("Manager");
        }

        public override void RequestVacation()
        {

        }
    }
}