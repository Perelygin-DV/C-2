using System;
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

        }
    }
}