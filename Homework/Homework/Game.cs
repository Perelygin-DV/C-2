using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Homework
{
    class Game
    {
        public static BaseObject[] _objs;


        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        private static List<Bullet> _bullet=new List<Bullet>();
        private static Asteroid[] _asteroids;
        private static Health[] _healths;
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));


        private static int width;
        private static int height;
        static Random rnd = new Random();

        private static Timer timer = new Timer { Interval = 100 };

        //Свойства
        // Ширина и высота игрового поля

        public static int Width { get { return width; } set { if (value > 3000 || value < 0) { throw new ArgumentOutOfRangeException(); return; } else { width = value; } } }
        public static int Height { get { return height; } set { if (value > 3000 || value < 0) { throw new ArgumentOutOfRangeException(); return; } else { height = value; } } }

        static Game()
        {

            if (timer.Interval > 100) throw new GameObjectException1("Too high speed", timer.Interval);
            timer.Start();
            timer.Tick += Timer_Tick;

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

            form.KeyDown += Form_KeyDown;

            Ship.MessageDie += Finish;


        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet.Add(new Bullet(new Point(_ship.Rect.X + 150, _ship.Rect.Y + 30), new Point(4, 0), new Size(4, 1)));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
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

            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();

            }

            foreach (Health h in _healths)
            {
                h?.Draw();

            }
            
            if (_bullet.Count != 0) { foreach (Bullet el in _bullet) el.Draw(); };

            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);

            Buffer.Render();
        }

        public static void Update()
        {

            int r = rnd.Next(5, 50);
            foreach (BaseObject obj in _objs)
                obj.Update();

            foreach (Bullet b in _bullet)
            {
                b?.Update();
                if (b.Dispose == true) _bullet.Remove(b);

            };



            for (int i = 0; i < _asteroids.Length; i++)
            {

                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();

                if (_bullet.Count != 0)
                {
                    for (int j = 0; j < _bullet.Count; j++)
                    {
                        if (_asteroids[i] != null && _bullet[j].Collision(_asteroids[i]))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            Console.WriteLine("Пуля и Астероиод");
                            _asteroids[i] = null;
                            _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
                            _bullet.RemoveAt(j);
                            j--;
                        }

                    }

                    if (_ship.Collision(_asteroids[i]))
                    {
                        var rnd = new Random();
                        r = rnd.Next(1, 10);
                        _ship?.EnergyLow(r);
                        Console.WriteLine($"Энергия уменьшилась на {r}, здоровья осталось {_ship.Energy}");
                        System.Media.SystemSounds.Asterisk.Play();
                        if (_ship.Energy <= 0) _ship.Die();
                    }


                }
            }

                for (int i = 0; i < _healths.Length; i++)
                {
                    if (_healths[i] == null) continue;
                    _healths[i].Update();

                    if (_ship.Collision(_healths[i]))
                    {
                        var rnd2 = new Random();
                        r = rnd2.Next(1, 10);
                        _ship?.EnergyHi( r);
                
                        Console.WriteLine($"Энергия увеличилась на {r}, здоровья осталось {_ship.Energy}");
                        System.Media.SystemSounds.Asterisk.Play();
              
                    }


                }


                // _bullet.Update();

            
        }


            public static void Load()
            {
                _objs = new BaseObject[30];
              //  _bullet = new List<Bullet>() { new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1)) };

                //_bullet.Add( new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1)));
                _asteroids = new Asteroid[3];
                _healths = new Health[5];
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

                for (var i = 0; i < _healths.Length; i++)
                {
                    int r = rnd.Next(5, 50);
                    _healths[i] = new Health(new Point(1000, rnd.Next(0, Game.Height)), new Point(r / 5, r), new Size(r, r));
                }


            }

            public static void Finish()
            {
                timer.Stop();
                Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
                Buffer.Render();
            }



        }
    } 
