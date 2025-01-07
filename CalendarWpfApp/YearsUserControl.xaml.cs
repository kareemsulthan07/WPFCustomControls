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
    /// Interaction logic for YearsUserControl.xaml
    /// </summary>
    public partial class YearsUserControl : UserControl
    {
        public event EventHandler<int> YearSelected;


        private Canvas canvas;
        private Line verticalLine1, verticalLine2, horizontalLine1, horizontalLine2, horizontalLine3;
        private Border border00, border10, border20,
            border01, border11, border21,
            border02, border12, border22,
            border03, border13, border23;

        private TextBlock textBlock1, textBlock2, textBlock3,
            textBlock4, textBlock5, textBlock6,
            textBlock7, textBlock8, textBlock9, textBlock10;

        private Brush defaultStroke = Brushes.LightGray;
        private double defaultStrokeThickness = 1;

        private int decadeStart, decadeEnd;


        #region dependency properties

        #endregion


        public YearsUserControl()
        {
            InitializeComponent();

            Initialize();
        }

        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PopulateDecadeYears(decadeStart - 1);
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
                PopulateDecadeYears(decadeEnd + 1);
            }
            catch (Exception)
            {

                throw;
            }
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
                    Name = nameof(border00)
                };
                border00.Child = textBlock1;
                border00.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border00.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border00);

                textBlock2 = new TextBlock()
                {
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
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border10)
                };
                border10.Child = textBlock2;
                border10.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border10.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border10);

                textBlock3 = new TextBlock()
                {
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
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border20)
                };
                border20.Child = textBlock3;
                border20.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border20.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border20);

                textBlock4 = new TextBlock()
                {
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
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border01)
                };
                border01.Child = textBlock4;
                border01.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border01.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border01);

                textBlock5 = new TextBlock()
                {
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
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border11)
                };
                border11.Child = textBlock5;
                border11.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border11.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border11);

                textBlock6 = new TextBlock()
                {
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
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border21)
                };
                border21.Child = textBlock6;
                border21.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border21.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border21);

                textBlock7 = new TextBlock()
                {
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
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border02)
                };
                border02.Child = textBlock7;
                border02.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border02.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border02);

                textBlock8 = new TextBlock()
                {
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
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border12)
                };
                border12.Child = textBlock8;
                border12.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border12.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border12);

                textBlock9 = new TextBlock()
                {
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
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border22)
                };
                border22.Child = textBlock9;
                border22.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border22.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border22);

                textBlock10 = new TextBlock()
                {
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
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border03)
                };
                border03.Child = textBlock10;
                border03.MouseLeftButtonDown += Border_MouseLeftButtonDown;
                border03.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                canvas.Children.Add(border03);

                border13 = new Border
                {
                    Background = Brushes.Transparent,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border13)
                };
                canvas.Children.Add(border13);

                border23 = new Border
                {
                    Background = Brushes.Transparent,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = nameof(border23)
                };
                canvas.Children.Add(border23);

                PopulateDecadeYears(DateTime.Now.Year);
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
                    }
                }
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
                //WriteLine(e.Delta);

                if (e.Delta > 0)
                {
                    // positive means up
                    PopulateDecadeYears(decadeStart - 1);
                }
                else
                {
                    // negative means down
                    PopulateDecadeYears(decadeEnd + 1);
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
                if (e.ClickCount == 2)
                {
                    //WriteLine(e.ClickCount);

                    var border = (Border)sender;
                    if (border.Child is TextBlock textBlock)
                    {
                        if (int.TryParse(textBlock.Text, out int year))
                        {
                            YearSelected?.Invoke(this, year);
                        }
                    }
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

        private void PopulateDecadeYears(int startYear)
        {
            try
            {
                // Normalize to decade start year (e.g., 2015 -> 2010)
                decadeStart = startYear - (startYear % 10);
                decadeEnd = decadeStart + 10;

                decadeTextBlock.Text = $"{decadeStart} - {decadeEnd - 1}";

                // Create and add TextBlocks for the first 10 years
                for (int i = 0; i < 10; i++)
                {
                    // Calculate column and row
                    int col = i % 3;
                    int row = i / 3;

                    var year = decadeStart + i;

                    // Get the corresponding border and add the TextBlock
                    Border border = FindBorderByName($"border{col}{row}");
                    if (border.Child is TextBlock textBlock)
                    {
                        border.Background = Brushes.Transparent;
                        textBlock.Foreground = Brushes.Black;

                        textBlock.Text = $"{year}";

                        if (year == DateTime.Now.Year)
                        {
                            border.Background = Brushes.Red;
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
    }
}
