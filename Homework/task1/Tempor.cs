using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Tempor:Element
    {

        private string fio;
        private double salary;

        public Tempor(string fio, double salary):base(fio,  salary) 
        {
            this.fio = fio;
            this.salary = salary;
        }


        
        
        public override double Calculate()
        {
            return 20.8*8*salary;
        }



    }
}
