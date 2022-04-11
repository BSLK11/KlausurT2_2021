using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KlausurT2
{
    abstract class Fahrzeug
    {
        public bool color = true;
        private bool isLeft;
        private double _position;
        private double _geschwindigkeit;

        public double Position { get => _position; set => _position = value; }
        public  double Geschwindigkeit { get => _geschwindigkeit; set => _geschwindigkeit = value; }

        static Random r = new Random();
        public Fahrzeug(Canvas canvas)
        {
            Position = r.Next(0, Convert.ToInt32(canvas.Width));
            Geschwindigkeit = 2400 * r.NextDouble();
        }
        public abstract void Bewegen(TimeSpan interval);
        public abstract void Zeichnen(Canvas canvas);

        public  void CollisionDetect(Canvas canvas)
        {
            if (Position > canvas.Width)
            {
                Position -= canvas.Width;
            }
            else if(Position < 0)
            {
                Position += canvas.Width;
            }
        }
        public void ChangeOrientationToLeft()
        {
            if(!isLeft)
            {
                Geschwindigkeit *= -1;
                isLeft = true;
            }
        }
        public void ChangeOrientationToRight()
        {
            if(isLeft)
            {
                Geschwindigkeit *= -1;
                isLeft=false;
            }
        }
        public void ChangeColor()
        {
            if (color)
            {
                color = false;
            }
            else
            {
                color = true;
            }
        }
    }
}
