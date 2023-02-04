using CPRG211D_Lab2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPRG211D_Lab2
{
    internal class Program
    {
        private static int numOfSalaried = 0;
        private static int numOfWaged = 0;
        private static int numOfPartTime =0;

        static void Main(string[] args)
        {
            //a. Fill a list with objects based on the supplied data file.
            List<Employee> employees = new List<Employee>();

            string path = "employees.txt";

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] cells = line.Split(':');

                string id = cells[0];
                string name = cells[1];
                string address = cells[2];
              
                string firstDigit = id.Substring(0, 1);

                int firstDigitInt = int.Parse(firstDigit);

                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {
                    // Salaried
                    string salary = cells[7];

                    double salaryDouble = double.Parse(salary);

                    Salaried salariedEmployee = new Salaried(id, name, address, salaryDouble);
                    employees.Add(salariedEmployee);
                } 
                else if (firstDigitInt >= 5 && firstDigitInt <= 7)
                {
                    // Waged
                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    Waged wagedEmployee = new Waged(id, name, address, rateDouble,hoursDouble);
                    employees.Add(wagedEmployee);
                }
                else if (firstDigitInt >= 8 && firstDigitInt <= 9) 
                {
                    // Part time
                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    PartTime partTimeEmployee = new PartTime(id, name, address, rateDouble, hoursDouble);
                    employees.Add(partTimeEmployee);
                }
            }    
            
            //b. Calculate and return the average weekly pay for all employees.
            double weeklyPaySum = 0;
                
            foreach (Employee employee in employees)
            {
                double weeklyPay = employee.CalculateWeeklyPay();

                weeklyPaySum += weeklyPay;
            }
                    
            double averageWeeklyPay= weeklyPaySum / employees.Count;

            Console.WriteLine("Average weekly pay: $" + String.Format("{0:0,0.00}", averageWeeklyPay) + "\n");

            //c. Calculate and return the highest weekly pay for the wage employees, including the name of the employee.
            Waged highestPaidWaged = null;
            
            foreach (Employee employee in employees)
            {
                if (employee is Waged)
                {
                    Waged wagedEmployee = (Waged)employee;

                    if (highestPaidWaged == null || wagedEmployee.CalculateWeeklyPay() > highestPaidWaged.CalculateWeeklyPay()) 
                    {
                        highestPaidWaged = wagedEmployee;
                    }
                }
            }
            Console.WriteLine("Highest waged employee: " + highestPaidWaged.Name);
            Console.WriteLine("Highest waged pay: $" + String.Format("{0:0,0.00}",highestPaidWaged.CalculateWeeklyPay()) + "\n");

            //d. Calculate and return the lowest salary for the salaried employees, including the name of the employee.
            Salaried lowestPaidSalaried = null;

            foreach (Employee employee in employees) 
            {
                if (employee is Salaried) 
                {
                    Salaried salariedEmployee = (Salaried)employee;

                    if (lowestPaidSalaried == null || salariedEmployee.CalculateWeeklyPay() < lowestPaidSalaried.CalculateWeeklyPay())
                    { 
                        lowestPaidSalaried = salariedEmployee;
                    }
                }
            }
            Console.WriteLine("Lowest Salaried employee: " + lowestPaidSalaried.Name);
            Console.WriteLine("Lowest salaried pay: $" + String.Format("{0:0,0.00}",lowestPaidSalaried.CalculateWeeklyPay()) + "\n");

            //e. What percentage of the company's employees fall into each employee category?
            foreach (Employee employee in employees)
            {   
                if (employee is Salaried) 
                {
                    numOfSalaried++;
                }
                else if (employee is Waged) 
                {
                    numOfWaged++;
                }
                else if (employee is PartTime)
                {
                    numOfPartTime++;
                }
            }

            double salariedEmployees = numOfSalaried / (double)employees.Count * 100;
            double wagedEmployees = numOfWaged / (double)employees.Count * 100;
            double partTimeEmployees = numOfPartTime / (double)employees.Count *100;

            Console.WriteLine("Salaried: " + numOfSalaried + "/" + employees.Count + "(" + String.Format("{0:0.00}",salariedEmployees) + "%)");
            Console.WriteLine("Waged: " + numOfWaged + "/" + employees.Count + "(" + String.Format("{0:0.00}",wagedEmployees) + "%)");
            Console.WriteLine("Part Time: " + numOfPartTime + "/" + employees.Count + "(" + String.Format("{0:0.00}",partTimeEmployees) + "%)");
        }
    }
}
