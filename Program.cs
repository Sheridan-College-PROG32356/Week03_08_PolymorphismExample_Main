using System;

namespace PolymorphismExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // create derived-class objects
            SalariedEmployee salariedEmployee = new SalariedEmployee(100, EmployeeType.SalariedEmployee, "John", "Williams", 500.0);
            HourlyEmployee hourlyEmployee = new HourlyEmployee(101, EmployeeType.HourlyEmployee, "Anna", "Smith", 50, 10.0);
            CommissionEmployee commissionEmployee = new CommissionEmployee(102, EmployeeType.CommissionEmployee, "Mark", "Lewis", 10000.0, 0.05);
            SalaryPlusCommissionEmployee salaryPlusCommissionEmployee = new SalaryPlusCommissionEmployee(103, EmployeeType.SalaryPlusCommissionEmployee, "Sue", "Jones", 10000.0, 0.06, 500.0);


            Console.WriteLine("Employees processed individually:\n\n");

            Console.WriteLine(salariedEmployee);
            Console.WriteLine($"Earnings: {salariedEmployee.Earnings():C}\n");

            Console.WriteLine(hourlyEmployee);
            Console.WriteLine($"Earnings: {hourlyEmployee.Earnings():C}\n");

            Console.WriteLine(commissionEmployee);
            Console.WriteLine($"Earnings: {commissionEmployee.Earnings():C}\n");

            Console.WriteLine(salaryPlusCommissionEmployee);
            Console.WriteLine($"Earnings: {salaryPlusCommissionEmployee.Earnings():C}\n");


            // create four-element Employee array
            Employee[] employees = new Employee[4];

            // initialize array with Employees of derived types
            employees[0] = new SalariedEmployee(100, EmployeeType.SalariedEmployee, "John", "Williams", 500.0);
            employees[1] = new HourlyEmployee(101, EmployeeType.HourlyEmployee, "Anna", "Smith", 50, 10.0);
            employees[2] = new CommissionEmployee(102, EmployeeType.CommissionEmployee, "Mark", "Lewis", 10000.0, 0.05);
            employees[3] = new SalaryPlusCommissionEmployee(103, EmployeeType.SalaryPlusCommissionEmployee, "Sue", "Jones", 10000.0, 0.06, 500.0);


            Console.WriteLine("\n\nEmployees processed polymorphically:\n\n");

            // generically process each element in array employees
            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp);     // invokes ToString

                // determine whether element is a SalaryPlusCommissionEmployee
                if (emp is SalaryPlusCommissionEmployee)
                {
                    // downcast Employee reference to
                    // SalaryPlusCommissionEmployee reference
                    SalaryPlusCommissionEmployee salCommEmployee = emp as SalaryPlusCommissionEmployee;

                    salCommEmployee.Salary *= 1.10;
                    Console.WriteLine($"New base salary with 10% increase is: {salCommEmployee.Salary:C}");
                }

                Console.WriteLine($"Earnings: {emp.Earnings():C}\n\n");
            }


            // get type name of each object in employees array
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"Employee {i} is a {employees[i].GetType()}");
            }
        }
    }
}
