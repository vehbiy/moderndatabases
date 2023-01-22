using System;

namespace OOP
{
    public class Worker : Employee
    {
        public override void SendReport()
        {
            Console.WriteLine("Worker");
        }

        public override void RequestVacation()
        {

        }
    }
}