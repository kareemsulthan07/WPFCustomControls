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

namespace CalendarWpfApp
{
    /// <summary>
    /// Interaction logic for DaysUserControl.xaml
    /// </summary>
    public partial class DaysUserControl : UserControl
    {
        public event EventHandler GoBackToMonths;

        private Canvas canvas;
        private Line verticalLine1, verticalLine2, verticalLine3,
            verticalLine4, verticalLine5, verticalLine6;
        private Border monBorder, tueBorder, wedBorder, thurBorder,
            friBorder, satBorder, sunBorder;
        private TextBlock monTextBlock, tueTextBlock, wedTextBlock,
            thurTextBlock, friTextBlock, satTextBlock, sunTextBlock;


        private readonly List<Line> horizontalLines = [];
        private readonly List<Border> dayBorders = [];
        private readonly List<TextBlock> dayTextBlocks = [];


        private int currentRows = 0;
        private Brush defaultStroke = Brushes.LightGray;
        private double defaultStrokeThickness = 1;


        public int Year { get; set; }
        public int Month { get; set; }


        public DaysUserControl()
        {
            InitializeComponent();

            Initialize();
        }


        private void Initialize()
        {
            try
            {
                canvas = new Canvas()
                {
                    SnapsToDevicePixels = true
                };

                InstantiateChildObjects();

                canvasBorder.Child = canvas;

                canvas.SizeChanged += canvas_SizeChanged;
                canvas.MouseWheel += Canvas_MouseWheel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void InstantiateChildObjects()
        {
            try
            {
                #region Instantiate the lines
                verticalLine1 = new Line
                {
                    Name = nameof(verticalLine1),
                    Stroke = defaultStroke,
                    StrokeThickness = defaultStrokeThickness
                };

                verticalLine2 = new Line
                {
                    Name = nameof(verticalLine2),
                    Stroke = defaultStroke,
                    StrokeThickness = defaultStrokeThickness
                };

                verticalLine3 = new Line
                {
                    Name = nameof(verticalLine3),
                    Stroke = defaultStroke,
                    StrokeThickness = defaultStrokeThickness
                };

                verticalLine4 = new Line
                {
                    Name = nameof(verticalLine4),
                    Stroke = defaultStroke,
                    StrokeThickness = defaultStrokeThickness
                };

                verticalLine5 = new Line
                {
                    Name = nameof(verticalLine5),
                    Stroke = defaultStroke,
                    StrokeThickness = defaultStrokeThickness
                };

                verticalLine6 = new Line
                {
                    Name = nameof(verticalLine6),
                    Stroke = defaultStroke,
                    StrokeThickness = defaultStrokeThickness
                };

                // Add the lines to the Canvas
                canvas.Children.Add(verticalLine1);
                canvas.Children.Add(verticalLine2);
                canvas.Children.Add(verticalLine3);
                canvas.Children.Add(verticalLine4);
                canvas.Children.Add(verticalLine5);
                canvas.Children.Add(verticalLine6);

                #endregion

                #region Instantiate TextBlock and Borders
                // TextBlocks
                monTextBlock = new TextBlock
                {
                    Foreground = Brushes.Black,
                    Name = nameof(monTextBlock),
                    FontWeight = FontWeights.SemiBold,
                    Text = "Monday",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                tueTextBlock = new TextBlock
                {
                    Foreground = Brushes.Black,
                    Name = nameof(tueTextBlock),
                    FontWeight = FontWeights.SemiBold,
                    Text = "Tuesday",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                wedTextBlock = new TextBlock
                {
                    Foreground = Brushes.Black,
                    Name = nameof(wedTextBlock),
                    FontWeight = FontWeights.SemiBold,
                    Text = "Wednesday",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                thurTextBlock = new TextBlock
                {
                    Foreground = Brushes.Black,
                    Name = nameof(thurTextBlock),
                    FontWeight = FontWeights.SemiBold,
                    Text = "Thursday",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                friTextBlock = new TextBlock
                {
                    Foreground = Brushes.Black,
                    Name = nameof(friTextBlock),
                    FontWeight = FontWeights.SemiBold,
                    Text = "Friday",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                satTextBlock = new TextBlock
                {
                    Foreground = Brushes.Black,
                    Name = nameof(satTextBlock),
                    FontWeight = FontWeights.SemiBold,
                    Text = "Saturday",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                sunTextBlock = new TextBlock
                {
                    Foreground = Brushes.Black,
                    Name = nameof(sunTextBlock),
                    FontWeight = FontWeights.SemiBold,
                    Text = "Sunday",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                // Borders
                monBorder = new Border
                {
                    Name = nameof(monBorder),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Child = monTextBlock
                };
                tueBorder = new Border
                {
                    Name = nameof(tueBorder),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Child = tueTextBlock
                };
                wedBorder = new Border
                {
                    Name = nameof(wedBorder),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Child = wedTextBlock
                };
                thurBorder = new Border
                {
                    Name = nameof(thurBorder),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Child = thurTextBlock
                };
                friBorder = new Border
                {
                    Name = nameof(friBorder),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Child = friTextBlock
                };
                satBorder = new Border
                {
                    Name = nameof(satBorder),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Child = satTextBlock,
                };
                sunBorder = new Border
                {
                    Name = nameof(sunBorder),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Child = sunTextBlock,
                };

                // Add the Border objects to the Canvas
                canvas.Children.Add(monBorder);
                canvas.Children.Add(tueBorder);
                canvas.Children.Add(wedBorder);
                canvas.Children.Add(thurBorder);
                canvas.Children.Add(friBorder);
                canvas.Children.Add(satBorder);
                canvas.Children.Add(sunBorder);
                #endregion

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void monthYearTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                GoBackToMonths?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Up();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Down();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                Redraw();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Canvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            try
            {
                if (e.Delta > 0)
                {
                    // positive means up
                    Up();
                }
                else
                {
                    // negative means down
                    Down();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                // represents double click
                if (e.ClickCount == 2)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Border_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                Border border = (Border)sender;
                var exceptBorders = canvas.Children.OfType<Border>().Where(b => b.Background == Brushes.Red)
                    .ToList();
                for (int i = 0; i < exceptBorders.Count; i++)
                {
                    exceptBorders[i].Background = Brushes.Transparent;

                    if (exceptBorders[i].Child is TextBlock textBlockX)
                        textBlockX.Foreground = Brushes.Black;
                }

                border.Background = Brushes.Red;
                if (border.Child is TextBlock textBlockY)
                    textBlockY.Foreground = Brushes.White;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Up()
        {
            try
            {
                if (Month == 1)
                    return;

                Month--;
                UpdateCalendar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Down()
        {
            try
            {
                if (Month == 12)
                    return;

                Month++;
                UpdateCalendar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateCalendar()
        {
            try
            {
                // Get first day of month and number of days
                DateTime dateTime = new DateTime(Year, Month, 1);
                int daysInMonth = DateTime.DaysInMonth(Year, Month);

                // Calculate required rows (including header row)
                // Convert Sunday-based DayOfWeek to Monday-based (0 = Monday, 6 = Sunday)
                int firstDayOfWeek = ((int)dateTime.DayOfWeek + 6) % 7;
                int totalDays = firstDayOfWeek + daysInMonth;
                int requiredRows = 1 + ((totalDays + 6) / 7); // Header row + calendar rows

                monthYearTextBlock.Text = $"{dateTime:MMMM, yyyy}";

                UpdateHorizontalLines(requiredRows);
                UpdateDayCells(daysInMonth);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateHorizontalLines(int requiredRows)
        {
            try
            {
                // Clear existing horizontal lines except the header line
                for (int i = horizontalLines.Count - 1; i >= 1; i--)
                {
                    canvas.Children.Remove(horizontalLines[i]);
                    horizontalLines.RemoveAt(i);
                }

                // Add new horizontal lines as needed
                for (int i = horizontalLines.Count; i < requiredRows; i++)
                {
                    Line line = new Line
                    {
                        Name = $"horizontalLine{i + 1}",
                        Stroke = defaultStroke,
                        StrokeThickness = defaultStrokeThickness,
                    };
                    canvas.Children.Add(line);
                    horizontalLines.Add(line);
                }

                currentRows = requiredRows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateDayCells(int daysInMonth)
        {
            try
            {
                // Clear existing day cells
                foreach (var border in dayBorders)
                {
                    border.MouseLeftButtonDown -= Border_MouseLeftButtonDown;
                    border.MouseLeftButtonUp -= Border_MouseLeftButtonUp;

                    canvas.Children.Remove(border);
                }
                dayBorders.Clear();
                dayTextBlocks.Clear();

                // Create new cells for the month
                for (int day = 1; day <= daysInMonth; day++)
                {
                    TextBlock textBlock = new TextBlock
                    {
                        FontSize = 14,
                        FontWeight = FontWeights.Normal,
                        Foreground = Brushes.Black,
                        Text = $"{day}",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    Border border = new Border
                    {
                        Background = Brushes.Transparent,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Child = textBlock,
                    };
                    border.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                    border.MouseLeftButtonUp += Border_MouseLeftButtonUp;

                    dayBorders.Add(border);
                    dayTextBlocks.Add(textBlock);
                    canvas.Children.Add(border);

                    if (day == DateTime.Now.Day &&
                        Month == DateTime.Now.Month &&
                        Year == DateTime.Now.Year)
                    {
                        border.Background = Brushes.Red;
                        textBlock.Foreground = Brushes.White;
                    }
                }

                Redraw();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Redraw()
        {
            if (currentRows == 0)
            {
                return;
            }

            double canvasWidth = canvas.ActualWidth;
            double canvasHeight = canvas.ActualHeight;

            // Calculate cell dimensions
            double columnWidth = canvasWidth / 7;
            double rowHeight = canvasHeight / currentRows;

            // Position header borders
            Border[] headerBorders = { monBorder, tueBorder, wedBorder, thurBorder, friBorder, satBorder, sunBorder };
            for (int i = 0; i < headerBorders.Length; i++)
            {
                Canvas.SetLeft(headerBorders[i], i * columnWidth);
                Canvas.SetTop(headerBorders[i], 0);
                headerBorders[i].Width = columnWidth;
                headerBorders[i].Height = rowHeight;
            }

            // Update vertical lines
            for (int i = 1; i <= 6; i++)
            {
                Line line = FindLineByName($"verticalLine{i}");
                double x = columnWidth * i;
                line.X1 = line.X2 = x;
                line.Y1 = 0;
                line.Y2 = canvasHeight;
            }

            // Update horizontal lines
            for (int i = 0; i < horizontalLines.Count; i++)
            {
                double y = rowHeight * (i + 1);
                horizontalLines[i].X1 = 0;
                horizontalLines[i].X2 = canvasWidth;
                horizontalLines[i].Y1 = horizontalLines[i].Y2 = y;
            }

            // Position day cells
            DateTime firstDay = new DateTime(Year, Month, 1);
            int firstDayOfWeek = ((int)firstDay.DayOfWeek + 6) % 7;

            for (int i = 0; i < dayBorders.Count; i++)
            {
                int position = firstDayOfWeek + i;
                int row = (position / 7) + 1; // +1 for header row
                int col = position % 7;

                Canvas.SetLeft(dayBorders[i], col * columnWidth);
                Canvas.SetTop(dayBorders[i], row * rowHeight);
                dayBorders[i].Width = columnWidth;
                dayBorders[i].Height = rowHeight;
            }
        }

        private Line FindLineByName(string name)
        {
            return canvas.Children.OfType<Line>().FirstOrDefault(line => line.Name == name);
        }
    }
}
