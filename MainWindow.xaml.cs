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

namespace ConvexHell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SliderPointAmount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LabelPCounter != null)
            {
                LabelPCounter.Content = "Amount of points: " + SliderPointAmount.Value;
            }
        }
        Vector[] points;
        int[] order;
        Vector center;
        private void ButtonGenerateDataset_Click(object sender, RoutedEventArgs e)
        {
            CanvasMap.Children.Clear();
            DatasetFactory datasetFactory = new DatasetFactory((uint)SliderPointAmount.Value, 50, (uint)CanvasMap.ActualWidth - 50, 50, (uint)CanvasMap.ActualHeight - 50);
            points = datasetFactory.GenerateDataset();
            order = datasetFactory.GenerateOrder();
            DrawPoints(points);
            DrawCenters(points);

        }

        public void DrawPoints(Vector[] points)
        {
            foreach (var item in points)
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)),
                    Stroke = null
                };
                ellipse.Margin = new Thickness(item.X, item.Y, 0, 0);
                CanvasMap.Children.Add(ellipse);
            }
        }
        
        public void DrawCenters(Vector[] vectors)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = 3,
                Height = 3,
                Fill = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0)),
                Stroke = null
            };
            ellipse.Margin = new Thickness(CanvasMap.Width/2, CanvasMap.Height/2, 0, 0);
            CanvasMap.Children.Add(ellipse);

            double centerX = 0;
            double centerY = 0;

            foreach (var item in vectors)
            {
                centerX += item.X;
                centerY += item.Y;
            }
            centerX = centerX / vectors.Length;
            centerY = centerY / vectors.Length;

            Ellipse ellipseCenter = new Ellipse
            {
                Width = 3,
                Height = 3,
                Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255)),
                Stroke = null
            };
            ellipse.Margin = new Thickness(centerX, centerY, 0, 0);
            CanvasMap.Children.Add(ellipseCenter);

        }

        private void ButtonDrawCenter_Click_1(object sender, RoutedEventArgs e)
        {

        }

        public void Solve(Vector[] vectors, int [] order)
        {

        }
    }
}
