using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Diagnostics.Debug;

namespace CircularProgressbarSampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point circleCenter;
        private double radius;
        private const double STROKE_THICKNESS_RATIO = 0.075; // 7.5% of container size
        private const double TEXT_SIZE_RATIO = 0.3; // 30% of container size

        ArcSegment progressSegment;
        PathFigure progressFigure;
        PathGeometry progressGeometry;

        EllipseGeometry fullCircle;


        public MainWindow()
        {
            // progress arc
            progressSegment = new ArcSegment()
            {
                SweepDirection = SweepDirection.Clockwise,
            };

            progressFigure = new PathFigure();
            progressFigure.Segments.Add(progressSegment);

            progressGeometry = new PathGeometry();
            progressGeometry.Figures.Add(progressFigure);

            // full circle to represent 100%
            fullCircle = new EllipseGeometry();


            InitializeComponent();
        }

        private void circleContainer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                CalculateCircleParameters();
                UpdateCircleLayout();
                UpdateProgress(progressSlider.Value);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void progressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                UpdateProgress(e.NewValue);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void CalculateCircleParameters()
        {
            // Get the smallest dimension to maintain aspect ratio
            try
            {
                double minDimension = Math.Min(circleContainer.ActualWidth, circleContainer.ActualHeight);

                // Calculate stroke thickness based on container size
                double strokeThickness = minDimension * STROKE_THICKNESS_RATIO;
                backgroundCircle.StrokeThickness = strokeThickness;
                progressArc.StrokeThickness = strokeThickness;

                // Calculate circle parameters
                circleCenter = new Point(circleContainer.ActualWidth / 2, circleContainer.ActualHeight / 2);
                radius = (minDimension / 2) - strokeThickness;

                // Update text size
                double textSize = minDimension * TEXT_SIZE_RATIO;
                textViewbox.Width = textSize * 2;  // Width is double the height for better proportions
                textViewbox.Height = textSize;

                // Center the text
                textViewbox.SetValue(Canvas.LeftProperty, (circleContainer.ActualWidth - textViewbox.Width) / 2);
                textViewbox.SetValue(Canvas.TopProperty, (circleContainer.ActualHeight - textViewbox.Height) / 2);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateCircleLayout()
        {
            try
            {
                // Update background circle
                backgroundGeometry.Center = circleCenter;
                backgroundGeometry.RadiusX = radius;
                backgroundGeometry.RadiusY = radius;

                // Update progress segment size
                progressSegment.Size = new Size(radius, radius);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateProgress(double percentage)
        {
            try
            {
                WriteLine($"percentage: {percentage}");

                progressArc.Visibility = percentage == 0 ? Visibility.Collapsed : Visibility.Visible;

                // Update percentage text
                percentageText.Text = $"{Math.Round(percentage)}%";

                // at 100%, the ArcSegment cannot directly represent a full circle.
                // hence, using the EllipseGeometry to represent 100%
                if (percentage == 100)
                {
                    // Create a full circle using EllipseGeometry
                    fullCircle.Center = circleCenter;
                    fullCircle.RadiusX = radius;
                    fullCircle.RadiusY = radius;      

                    progressArc.Data = fullCircle; // Set as the Path's geometry
                }
                else
                {
                    // Calculate the angles for the arc
                    double angleInDegrees = (percentage / 100) * 360;
                    double angleInRadians = (angleInDegrees - 90) * (Math.PI / 180);

                    // Calculate end point of the arc
                    double endX = circleCenter.X + (radius * Math.Cos(angleInRadians));
                    double endY = circleCenter.Y + (radius * Math.Sin(angleInRadians));

                    // Set starting point (top of circle)
                    progressFigure.StartPoint = new Point(circleCenter.X, circleCenter.Y - radius);

                    // Update the arc segment
                    progressSegment.Point = new Point(endX, endY);
                    progressSegment.IsLargeArc = angleInDegrees > 180;

                    progressArc.Data = progressGeometry;
                }

                // Optional: Animate the progress change
                AnimateProgress(percentage);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AnimateProgress(double targetValue)
        {
            // Create a double animation for smooth transition
            try
            {
                DoubleAnimation animation = new DoubleAnimation
                {
                    To = targetValue,
                    Duration = TimeSpan.FromMilliseconds(300),
                    EasingFunction = new QuadraticEase()
                };

                // Apply the animation to the slider
                progressSlider.BeginAnimation(Slider.ValueProperty, animation);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}