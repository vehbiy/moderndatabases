using System.Collections.Generic;

namespace OOP
{
    public class President2
    {
        private List<Employee2> allEmployees = new List<Employee2>();

        public President2()
        {
            this.allEmployees.Add(new Employee2("Worker"));
            this.allEmployees.Add(new Employee2("Manager"));
            this.allEmployees.Add(new Employee2("VicePresident"));
        }

        public void CollectReports()
        {
            foreach (Employee2 employee in this.allEmployees)
            {
                employee.SendReport();
            }
        }
    }
}