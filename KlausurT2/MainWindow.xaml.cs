using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KlausurT2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Fahrzeug[] Fahrzeugs = new Fahrzeug[20];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            rnd.Next(0, 10);

            for (int i = 0; i < 10; i++)
            {
                Fahrzeugs[i] = new PKW(canvas);
                Fahrzeugs[i + 10] = new LKW(canvas);
            }
            canvas.Children.Clear();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            timer.Tick += OntimeEvent;
            timer.Start();

        }
        void OntimeEvent(object? sender, EventArgs e)
        {
            canvas.Children.Clear();
            foreach (Fahrzeug item in Fahrzeugs)
            {
                item.Bewegen(timer.Interval);
                item.Zeichnen(canvas);
                item.CollisionDetect(canvas);
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (Fahrzeug item in Fahrzeugs)
            {
                if (Key.Left == e.Key)
                {
                    item.ChangeOrientationToLeft();
                }
                else if (Key.Right == e.Key)
                {
                    item.ChangeOrientationToRight();
                }
                else if (Key.S == e.Key)
                {
                    item.ChangeColor();
                }
            }

        }
    }
}
