using System.Collections.Generic;

namespace OOP
{
    public class President : Employee
    {
        private List<Employee> allEmployees = new List<Employee>();

        public President()
        {
            this.allEmployees.Add(new Worker());
            this.allEmployees.Add(new Worker());
            this.allEmployees.Add(new Worker());
            this.allEmployees.Add(new Worker());
            this.allEmployees.Add(new MasterWorker());
            this.allEmployees.Add(new MasterWorker());
            this.allEmployees.Add(new Manager());
            this.allEmployees.Add(new Manager());
            this.allEmployees.Add(new VicePresident());
        }

        public override void SendReport()
        {	
        }

        public override void RequestVacation()
        {

        }

        public void CollectReports()
        {
            foreach(Employee employee in this.allEmployees)
            {
                employee.SendReport();
            }
        }
    }
}