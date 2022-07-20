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

namespace GlyphIconButtonSampleApp
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
    }

    public enum GlyphIconPosition
    {
        Left,
        Top,
        Right,
        Bottom
    }

    public class GlyphIconButton : Button
    {
        public GlyphIconPosition Position
        {
            get { return (GlyphIconPosition)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Position.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(GlyphIconPosition), typeof(GlyphIconButton), new PropertyMetadata(GlyphIconPosition.Left));


        public string GlyphIcon
        {
            get { return (string)GetValue(GlyphIconProperty); }
            set { SetValue(GlyphIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GlyphIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GlyphIconProperty =
            DependencyProperty.Register("GlyphIcon", typeof(string), typeof(GlyphIconButton), new PropertyMetadata(""));


        private TextBlock glyphIconTextBlock;


        public GlyphIconButton()
        {
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (Template.FindName("glyphIconTextBlock", this) is TextBlock textBlock)
            {
                glyphIconTextBlock = textBlock;
                AdjustGlyphIcon();
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            switch (e.Property.Name)
            {
                case "Position":
                    AdjustGlyphIcon();
                    break;

                case "GlyphIcon":
                    break;

                default:
                    break;
            }
        }

        private void AdjustGlyphIcon()
        {
            try
            {
                switch (Position)
                {
                    case GlyphIconPosition.Left:
                        glyphIconTextBlock.Margin = new Thickness(0, 0, 2.5d, 0);
                        Grid.SetRow(glyphIconTextBlock, 1);
                        Grid.SetColumn(glyphIconTextBlock, 0);
                        break;

                    case GlyphIconPosition.Top:
                        glyphIconTextBlock.Margin = new Thickness(0, 0, 0, 2.5d);
                        Grid.SetRow(glyphIconTextBlock, 0);
                        Grid.SetColumn(glyphIconTextBlock, 1);
                        break;

                    case GlyphIconPosition.Right:
                        glyphIconTextBlock.Margin = new Thickness(2.5d, 0, 0, 0);
                        Grid.SetRow(glyphIconTextBlock, 1);
                        Grid.SetColumn(glyphIconTextBlock, 2);
                        break;

                    case GlyphIconPosition.Bottom:
                        glyphIconTextBlock.Margin = new Thickness(0, 2.5d, 0, 0);
                        Grid.SetRow(glyphIconTextBlock, 2);
                        Grid.SetColumn(glyphIconTextBlock, 1);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
