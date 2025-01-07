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
    /// Interaction logic for MonthsUserControl.xaml
    /// </summary>
    public partial class MonthsUserControl : UserControl
    {
        public event EventHandler GoBackToYears;
        public event EventHandler<int> MonthSelected;


        private Canvas canvas;
        private Line verticalLine1, verticalLine2, horizontalLine1, horizontalLine2, horizontalLine3;
        private Border border00, border10, border20,
            border01, border11, border21,
            border02, border12, border22,
            border03, border13, border23;


        private TextBlock textBlock1, textBlock2, textBlock3,
            textBlock4, textBlock5, textBlock6,
            textBlock7, textBlock8, textBlock9,
            textBlock10, textBlock11, textBlock12;

        private Brush defaultStroke = Brushes.LightGray;
        private double defaultStrokeThickness = 1;

        private int _year;
        public int Year
        {
            get => _year;
            set
            {
                _year = value;

                yearTextBlock.Text = $"{Year}";
            }
        }

        public int Month { get; set; }



        public MonthsUserControl()
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
                #region Instantiate and add Line objects and add Line objects
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

                horizontalLine1 = new Line
                {
                    Name = nameof(horizontalLine1),
                    Stroke = defaultStroke,
                    StrokeThickness = defaultStrokeThickness
                };

                horizontalLine2 = new Line
                {
                    Name = nameof(horizontalLine2),
                    Stroke = defaultStroke,
                    StrokeThickness = defaultStrokeThickness
                };

                horizontalLine3 = new Line
                {
                    Name = nameof(horizontalLine3),
                    Stroke = defaultStroke,
                    StrokeThickness = defaultStrokeThickness
                };

                // Add lines to the Canvas
                canvas.Children.Add(verticalLine1);
                canvas.Children.Add(verticalLine2);
                canvas.Children.Add(horizontalLine1);
                canvas.Children.Add(horizontalLine2);
                canvas.Children.Add(horizontalLine3);
                #endregion

                #region Instantiate and add TextBlock and Border objects
                textBlock1 = new TextBlock()
                {
                    Text = "January",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border00 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border00),
                    Tag = 1,
                };
                border00.Child = textBlock1;
                border00.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border00.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border00);

                textBlock2 = new TextBlock()
                {
                    Text = "February",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border10 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border10),
                    Tag = 2,
                };
                border10.Child = textBlock2;
                border10.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border10.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border10);

                textBlock3 = new TextBlock()
                {
                    Text = "March",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border20 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border20),
                    Tag = 3,
                };
                border20.Child = textBlock3;
                border20.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border20.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border20);

                textBlock4 = new TextBlock()
                {
                    Text = "April",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border01 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border01),
                    Tag = 4,
                };
                border01.Child = textBlock4;
                border01.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border01.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border01);

                textBlock5 = new TextBlock()
                {
                    Text = "May",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border11 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border11),
                    Tag = 5,
                };
                border11.Child = textBlock5;
                border11.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border11.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border11);

                textBlock6 = new TextBlock()
                {
                    Text = "June",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border21 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border21),
                    Tag = 6,
                };
                border21.Child = textBlock6;
                border21.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border21.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border21);

                textBlock7 = new TextBlock()
                {
                    Text = "July",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border02 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border02),
                    Tag = 7,
                };
                border02.Child = textBlock7;
                border02.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border02.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border02);

                textBlock8 = new TextBlock()
                {
                    Text = "August",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border12 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border12),
                    Tag = 8,
                };
                border12.Child = textBlock8;
                border12.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border12.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border12);

                textBlock9 = new TextBlock()
                {
                    Text = "September",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border22 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border22),
                    Tag = 9,
                };
                border22.Child = textBlock9;
                border22.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border22.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border22);

                textBlock10 = new TextBlock()
                {
                    Text = "October",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border03 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border03),
                    Tag = 10,
                };
                border03.Child = textBlock10;
                border03.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border03.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border03);

                textBlock11 = new TextBlock()
                {
                    Text = "November",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border13 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border13),
                    Tag = 11,
                };
                border13.Child = textBlock11;
                border13.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border13.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border13);

                textBlock12 = new TextBlock()
                {
                    Text = "December",
                    FontSize = 14,
                    FontWeight = FontWeights.Normal,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                };
                border23 = new Border
                {
                    Background = Brushes.Transparent,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Name = nameof(border23),
                    Tag = 12,
                };
                border23.Child = textBlock12;
                border23.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border23.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border23);

                #endregion
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

        private void yearTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                GoBackToYears?.Invoke(this, EventArgs.Empty);
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
                if (e.ClickCount == 2)
                {
                    Border border = (Border)sender;

                    MonthSelected?.Invoke(this, (int)border.Tag);
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

        public void Refresh()
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

        private void Redraw()
        {
            try
            {
                double canvasWidth = canvas.ActualWidth;
                double canvasHeight = canvas.ActualHeight;
                double columnWidth = canvasWidth / 3;
                double rowHeight = canvasHeight / 4;

                // Update vertical lines
                verticalLine1.X1 = verticalLine1.X2 = columnWidth;
                verticalLine1.Y1 = 0;
                verticalLine1.Y2 = canvasHeight;

                verticalLine2.X1 = verticalLine2.X2 = columnWidth * 2;
                verticalLine2.Y1 = 0;
                verticalLine2.Y2 = canvasHeight;

                // Update horizontal lines
                for (int i = 1; i <= 3; i++)
                {
                    Line line = FindLineByName($"horizontalLine{i}");
                    line.X1 = 0;
                    line.X2 = canvasWidth;
                    line.Y1 = line.Y2 = rowHeight * i;
                }

                // Update Border positions and sizes
                for (int col = 0; col < 3; col++)
                {
                    for (int row = 0; row < 4; row++)
                    {
                        Border border = FindBorderByName($"border{col}{row}");
                        Canvas.SetLeft(border, col * columnWidth);
                        Canvas.SetTop(border, row * rowHeight);
                        border.Width = columnWidth;
                        border.Height = rowHeight;

                        if ((int)border.Tag == Month)
                        {
                            border.Background = Brushes.Red;

                            if (border.Child is TextBlock textBlock)
                                textBlock.Foreground = Brushes.White;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Line FindLineByName(string name)
        {
            return canvas.Children.OfType<Line>().FirstOrDefault(line => line.Name == name);
        }

        private Border FindBorderByName(string name)
        {
            return canvas.Children.OfType<Border>().FirstOrDefault(border => border.Name == name);
        }

        public void ClearBorders()
        {
            try
            {
                for (int col = 0; col < 3; col++)
                {
                    for (int row = 0; row < 4; row++)
                    {
                        Border border = FindBorderByName($"border{col}{row}");
                        border.Background = Brushes.Transparent;

                        if (border.Child is TextBlock textBlock)
                            textBlock.Foreground = Brushes.Black;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
