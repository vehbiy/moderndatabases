using System;

namespace OOP
{
    public class Employee2
    {
        private string employeeType;

        public Employee2(string employeeType)
        {
            this.employeeType = employeeType;
        }

        public void SendReport()
        {
            switch(this.employeeType)
            {
                case "Worker":
                    Console.WriteLine("Worker report");
                    break;
				case "Manager":
                    Console.WriteLine("Manager report");
					break;
				case "VicePresident":
                    Console.WriteLine("VicePresident report");
					break;
				case "PrincipalWorker":
					Console.WriteLine("PrincipalWorker report");
					break;
                default:
                    break;
            }
        }

        public void RequestVacation()
        {
            switch (this.employeeType)
            {
                case "Worker":
                    Console.WriteLine("Worker vacation");
                    break;
                case "Manager":
                    Console.WriteLine("Manager vacation");
                    break;
                case "VicePresident":
                    Console.WriteLine("VicePresident vacation");
                    break;
            }
        }
    }
}
