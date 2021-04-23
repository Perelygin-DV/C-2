using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Homework
{
    class Game
    {
        public static BaseObject [] _objs; 


        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        private static Bullet _bullet;
        private static Asteroid []_asteroids;


        private static int width;
        private static int height;

        //Свойства
        // Ширина и высота игрового поля

        public static int Width { get { return width; } set { if (value > 3000 || value < 0) { throw new ArgumentOutOfRangeException();return; } else { width = value; } } }
        public static int Height { get { return height; } set { if (value > 3000 || value < 0) { throw new ArgumentOutOfRangeException(); return; } else { height = value; } } }

        static Game()
        {

        }
        public static void Init(Form form)
        {
            //Графическое свойство для вывода графики

            Graphics g;

            // Предоставляет доступ к главному буферу графического контекста для текущего приложения;

            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            //Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            //Связываем буфер памяти с графическим объектом, чтобы рисовать в буфере

            Load();
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 100 };
            if (timer.Interval > 100) throw new GameObjectException1("Too high speed", timer.Interval);
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            //Проверка вывода графики

            Buffer.Graphics.Clear(Color.Black);
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();

            foreach (Asteroid obj in _asteroids)
            {
                obj.Draw();

            }
            _bullet.Draw();

            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();




            foreach (Asteroid obj in _asteroids)
            {
                obj.Update();
                if (obj.Collision(_bullet)) { System.Media.SystemSounds.Hand.Play(); _bullet.Regen(obj, Width, Height); }

            }

            _bullet.Update();

        }


        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[3];
            var rnd = new Random();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
            }

        }



    }
}
