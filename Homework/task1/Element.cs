using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
     class Element: IComparable 
    {
        Element[] list;
        private readonly string _fio;
        private readonly double _salary;
        public Element(string fio, double salary)
        {
            _fio = fio;
            _salary = salary;
        }

        public string FIO => _fio;
        public double Salary => _salary;



        public int CompareTo(object obj)
        {
            if (_salary < ((Element)obj).Salary) return 1;
            if (_salary > ((Element)obj).Salary) return -1;
            return 0;
        }





        // public void Read()
        //{
        //    StreamReader sr = new StreamReader("data.txt");
        //    int n = int.Parse(sr.ReadLine());
        //    list = new Element[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        string[] s = sr.ReadLine().Split(' ');
        //        int sal = Int32.Parse(s[2]) ;
        //        list[i] = new Element(s[0] + " " + s[1], sal);
        //    }

        //    sr.Close();
        //    Array.Sort(list);
        //}

        public virtual double Calculate() { return 0; }


        public override string ToString()
        {
            return $"{FIO} get {Salary} rublei";
        }


    }
}
