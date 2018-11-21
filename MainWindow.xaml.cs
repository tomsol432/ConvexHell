using MIConvexHull;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
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
        Random random = new Random();
        private void ButtonGenerateDataset_Click(object sender, RoutedEventArgs e)
        {
            CanvasMap.Children.Clear();
            DatasetFactory datasetFactory = new DatasetFactory((uint)SliderPointAmount.Value, 50, (uint)CanvasMap.ActualWidth - 50, 50, (uint)CanvasMap.ActualHeight - 50);
            points = datasetFactory.GenerateDataset();
            order = datasetFactory.GenerateOrder();
            DrawPoints(points);
            DrawCenters(points);
            Solve(center, points, order);
          

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
            ellipse.Margin = new Thickness(CanvasMap.ActualWidth/2, CanvasMap.ActualHeight/2, 0, 0);
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
            center = new Vector(centerX, centerY);
            ellipse.Margin = new Thickness(centerX, centerY, 0, 0);
            CanvasMap.Children.Add(ellipseCenter);

        }
        
       
        public void Solve(Vector center,Vector[] vectors, int [] order)
        {
            var verticles = new FastVector[vectors.Length];
            for (int i = 0; i < verticles.Length; i++)
            {
                verticles[i] = new FastVector(vectors[i].X, vectors[i].Y);
            }

            var convex = ConvexHull.Create(verticles).Points.ToArray();

            DrawHull(convex);


        }
        void DrawHull(FastVector[] convexData)
        {
            for (int i = 0; i < convexData.Length; i++)
            {
                if (i < convexData.Length - 1)
                {
                    Line line = new Line()
                    {
                        X1 = convexData[i].Position[0] + 5,
                        Y1 = convexData[i].Position[1] + 5,

                        X2 = convexData[i + 1].Position[0] + 5,
                        Y2 = convexData[i + 1].Position[1] +5,
                        StrokeThickness = 2,
                        Stroke = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
                    };
                    CanvasMap.Children.Add(line);
                }

                if (i == convexData.Length - 1)
                {
                    Line line = new Line()
                    {

                        X1 = convexData[i].Position[0] +5,
                        Y1 = convexData[i].Position[1] +5,

                        X2 = convexData[0].Position[0] +5,
                        Y2 = convexData[0].Position[1] +5,

                        StrokeThickness = 2,
                        Stroke = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
                    };

                    CanvasMap.Children.Add(line);
                }
            }
        }


               
            
       

        private static double GetDistance(Vector A, Vector B)
        {
            double a = (double)(B.X - A.X);
            double b = (double)(B.Y - A.Y);

            return Math.Sqrt(a * a + b * b);
        }

       
    }
}
