using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework
{
    class Star : BaseObject
    {
        static Random rnd = new Random();
        //static BaseObject[] _objs;

        public static Image[] Img= new Image[] { Image.FromFile("favourites.png"), Image.FromFile("star (1).png"), Image.FromFile("star.png") };
        //Image img;
        

        public Star(Point pos, Point dir, Size size): base (pos, dir, size)
        {
            //_objs = new BaseObject[30];
            //for (int i = 0; i < _objs.Length; i++)
            //{
            //    _objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(20, 20));
            //}
            
        }


        static Image GetImg()
        {
            int i = rnd.Next(0, 2);
            
            return Img[i];
        }

        Image img2 = GetImg();
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img2,Pos);

            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y < 0) Pos.Y = Game.Height + Size.Height;

            if (Pos.X > Game.Width) { Pos.X = 0; Pos.X += Size.Width; };

            //if (Pos.Y > Game.Height) { Pos.Y = 0; Pos.Y += Size.Height; };
        }



    }
}
