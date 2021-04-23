using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Const:Element
    {
        private string fio;
        private double salary;

        public Const(string fio, double salary) : base(fio, salary)
        {
            this.fio = fio;
            this.salary = salary;
        }




        public override double Calculate()
        {
            return salary;
        }

    }
}
