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

        //Свойства
        // Ширина и высота игрового поля

        public static int Width { get; set; }
        public static int Height { get; set; }

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
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.White, new RectangleF(100, 100, 200, 200));
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }


        public static void Load()
        {
            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length / 2; i++)
                _objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
                _objs[i] = new Star(new Point(1000, i * 15), new Point(i, 0), new Size(5, 10));

        }



    }
}
