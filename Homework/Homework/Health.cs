using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Health : BaseObject, ICloneable
    {

        public int Power { get; set; }
        static Image img = Image.FromFile("heart.png");

        public Health(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }


        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);

           
        }

        


        public object Clone()
        {
            Health health = new Health(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            health.Power = Power;
            return health;
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width ;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y < 0) Pos.Y = Game.Height + Size.Height;

            if (Pos.X > Game.Width) { Pos.X = 0; Pos.X += Size.Width; };
        }
    }
}
