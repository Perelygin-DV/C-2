using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {


        static void Main(string[] args)
        {
            ArrayWorkers worker = new ArrayWorkers(20);

            foreach (var item in worker.workers)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine($"\n \n ----------------------------------- ");
            Array.Sort(worker.workers);

            foreach (var item in worker.workers)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
        
    }
}
