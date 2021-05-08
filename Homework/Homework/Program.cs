using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
            Height = Screen.PrimaryScreen.Bounds.Height
            
            };
            //form.Width = 800;
            //form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Load();

            Game.Draw();
           
            Application.Run(form);


            SortedSet<int> a = new SortedSet<int>();
            a.Add(1);
            a.Add(1);
            List<int> b = new List<int>();


            var dict = new Dictionary<char, string>();
            dict['a'] = "jk";
            dict['b'] = "mm";
            dict['c'] = "rr";
            foreach(KeyValuePair<char,string> ob in dict)
            {
                Console.WriteLine(ob.Key);
            }




        }
    }
}