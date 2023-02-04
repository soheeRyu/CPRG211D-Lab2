using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CPRG211D_Lab2.Entities
{
    internal class Employee 
    {
        protected string id;
        protected string name;
        protected string address;

        public string ID { get { return id; } }
        public string Name { get { return name; } }
        public string Address { get { return address; } }

        public Employee() { }
              
        public Employee(string id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        public virtual double CalculateWeeklyPay()
        {
            return 0;
        }
    }
}
