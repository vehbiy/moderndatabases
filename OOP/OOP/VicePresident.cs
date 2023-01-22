using System;

namespace OOP
{
    public class VicePresident : Manager
    {
        public override void SendReport()
        {
            Console.WriteLine("VicePresident");
        }

        public override void RequestVacation()
        {

        }
    }
}