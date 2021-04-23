using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Homework
{
    abstract class  BaseObject: ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
       // private Image[] img;

        protected BaseObject (Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

      

        public abstract void Draw();

        public abstract void Update();
      
        public Point DIR { get { return this.Dir; } set { this.Pos = value; } }

        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);


        public void Regen(BaseObject obj, int Width, int Height)
        {

            if (this.Dir.X > 0) { this.Pos.X = 0; obj.Pos.X = Width; };

            if (this.Dir.X < 0) { this.Pos.X = Width; obj.Pos.X = 0; };


            if (this.Dir.Y > 0) { this.Pos.Y = Height; obj.Pos.Y = 0; };

            if (this.Dir.Y < 0) { this.Pos.Y = 0; obj.Pos.Y = Height; };

        }



    }
}
