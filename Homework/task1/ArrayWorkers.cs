using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class ArrayWorkers: IEnumerable
    {

        public Element[] workers;
        Random rnd = new Random();



        public ArrayWorkers(int col)
        {
            workers = new Element[col];

            for (int i = 0; i < col; i++)
            {

                if (col % 2 == 0) workers[i] = new Const("Worker " + i, rnd.Next(8000, 25000));
                else workers[i] = new Tempor("Worker " + i, rnd.Next(100, 200));
            }


        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                yield return this.workers[i];
            }
            
        }



    }
}
