using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KlausurT2
{
    internal class PKW : Fahrzeug
    {
        static Random r = new Random();

        public PKW(Canvas canvas)
            : base(canvas)
        {
            Position = r.Next(0, Convert.ToInt32(canvas.Width));
            Geschwindigkeit = 3000;
        }


        public override void Bewegen(TimeSpan interval)
        {
            Position += Geschwindigkeit * interval.TotalMinutes;
        }
        public override void Zeichnen(Canvas canvas)
        {
            Ellipse e = new Ellipse();
            e.Width = 10;
            e.Height = 10;
            if (color)
            {
                e.Fill = Brushes.Blue;
            }
            else
            {
                e.Fill = Brushes.Gray;
            }
            Canvas.SetLeft(e, Position);
            Canvas.SetTop(e, 100);
            canvas.Children.Add(e);
        }
       

    }
}
