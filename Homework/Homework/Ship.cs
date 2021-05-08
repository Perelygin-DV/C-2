using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public delegate void Message();

    class Ship : BaseObject
    {

        public static event Message MessageDie;

        private int _energy = 100;
        public int Energy => _energy;
        static Image img = Image.FromFile("rocket.png");
        public void EnergyLow (int n)
        {
            _energy -= n;
        }

        public void EnergyHi(int n)
        {
            _energy += n;
            if (_energy > 100) _energy = 100;
        }




        public Ship (Point pos, Point dir, Size size): base(pos, dir, size) 
        { 
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }

        public override void Update()
        {
            
        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public void Die()
        {
            MessageDie?.Invoke();

        }
    }
}
