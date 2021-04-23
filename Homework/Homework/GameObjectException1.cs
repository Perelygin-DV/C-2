using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class GameObjectException1: Exception
    {
        private string msg;

        public GameObjectException1(string mes, int a) : base(mes+" " +a) { }
        
        
       
    
        public override string ToString()
        {
            return msg;
        }



    }
}
