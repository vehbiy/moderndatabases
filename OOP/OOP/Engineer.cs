using System;

namespace OOP
{
    public class Engineer : Employee
    {
        public override void SendReport()
        {
            Console.WriteLine("Engineer");
        }

        public override void RequestVacation()
        {
            
        }
    }
}