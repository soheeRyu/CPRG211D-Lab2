using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211D_Lab2.Entities
{
    internal class Waged : Employee
    {
        private double rate;
        private double hours;

        public double Rate { get { return rate; } }
        public double Hours { get { return hours; } }

        public Waged(string id, string name, string address, double rate, double hours)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hours = hours;
        }

        public override double CalculateWeeklyPay()
        {
            double weeklyPay = 0;

            if (this.hours < 40)
            {
                weeklyPay = this.hours * this.rate;
            }
            else
            {
                double overtimePay = 40 * this.rate + (this.hours - 40) * (this.rate * 1.5);

                weeklyPay += overtimePay;
            }

            return weeklyPay;
        }
    }
}
