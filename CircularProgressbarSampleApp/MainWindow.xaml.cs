using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CircularProgressbarSampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int progress = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void IncrementProgress_Click(object sender, RoutedEventArgs e)
        {
            progress += 10;
            if (progress > 100) progress = 0;
            UpdateProgressB(progress);
        }

        private void UpdateProgressA(int percentage)
        {
            ProgressText.Text = $"{percentage}%";

            double angle = percentage * 3.6; // 3.6 degrees per percentage point
            Point endPoint = CalculatePoint(angle, 90);

            ProgressArcSegment.IsLargeArc = angle > 180;
            ProgressArcSegment.Point = endPoint;
        }

        private void UpdateProgressB(int percentage)
        {
            ProgressText.Text = $"{percentage}%";

            if (percentage >= 100)
            {
                // Create a full circle
                ProgressArc.Data = new EllipseGeometry(new Point(100, 100), 90, 90);
            }
            else
            {
                double angle = percentage * 3.6; // 3.6 degrees per percentage point
                Point endPoint = CalculatePoint(angle, 90);

                PathFigure figure = new PathFigure();
                figure.StartPoint = new Point(100, 10);

                ArcSegment arc = new ArcSegment();
                arc.Point = endPoint;
                arc.Size = new Size(90, 90);
                arc.IsLargeArc = angle > 180;
                arc.SweepDirection = SweepDirection.Clockwise;

                PathGeometry geometry = new PathGeometry();
                figure.Segments.Add(arc);
                geometry.Figures.Add(figure);

                ProgressArc.Data = geometry;
            }
        }

        private Point CalculatePoint(double angle, double radius)
        {
            double angleRad = (angle - 90) * (Math.PI / 180);
            double x = 100 + radius * Math.Cos(angleRad);
            double y = 100 + radius * Math.Sin(angleRad);
            return new Point(x, y);
        }
    }
}