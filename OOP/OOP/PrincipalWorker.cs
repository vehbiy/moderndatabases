using System;

namespace OOP
{
    public class PrincipalWorker : Employee
    {
        public override void SendReport()
        {
            Console.WriteLine("PrincipalWorker report");
        }

        public override void RequestVacation()
        {
            // TODO: Important
            throw new NotImplementedException();
        }
    }
}