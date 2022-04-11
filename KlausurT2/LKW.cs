using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KlausurT2
{

    internal class LKW : Fahrzeug
    {
        static Random r = new Random();

        public LKW(Canvas canvas)
            : base(canvas)
        {
            Position = r.Next(0, Convert.ToInt32(canvas.Width));
            Geschwindigkeit = 2000;
        }

        public override void Bewegen(TimeSpan interval)
        {
            Position += Geschwindigkeit * interval.TotalMinutes;
        }
        public override void Zeichnen(Canvas canvas)
        {
            Rectangle e = new Rectangle();
            e.Width = 30;
            e.Height = 10;
            if (color)
            {
                e.Fill = Brushes.Gray;
            }
            else
            {
                e.Fill = Brushes.Blue;
            }
            Canvas.SetLeft(e, Position);
            Canvas.SetTop(e, 300);
            canvas.Children.Add(e);
        }
    }
}
