using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace EditableTextBlockSample
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

    public class EditableTextBlock : Grid
    {
        private TextBlock textBlock;
        private TextBox textBox;


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableTextBlock), new PropertyMetadata(""));


        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(double), typeof(EditableTextBlock), new PropertyMetadata(16d));




        public bool IsEditing
        {
            get { return (bool)GetValue(IsEditingProperty); }
            set { SetValue(IsEditingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsEditing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEditingProperty =
            DependencyProperty.Register("IsEditing", typeof(bool), typeof(EditableTextBlock), new PropertyMetadata(false));





        public EditableTextBlock()
        {
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                textBlock = new TextBlock()
                {
                    FontSize = FontSize,
                    Visibility = Visibility.Visible,
                    SnapsToDevicePixels = this.SnapsToDevicePixels,
                    TextWrapping = TextWrapping.Wrap,
                };
                textBox = new TextBox()
                {
                    FontSize = FontSize,
                    Visibility = Visibility.Collapsed,
                    SnapsToDevicePixels = this.SnapsToDevicePixels,
                    TextWrapping = TextWrapping.Wrap,
                };

                this.Children.Add(textBlock);
                this.Children.Add(textBox);

                textBox.KeyDown += TextBox_KeyDown;
                textBox.LostFocus += TextBox_LostFocus;
                textBox.LostKeyboardFocus += TextBox_LostKeyboardFocus;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Escape)
                {
                    textBlock.Visibility = Visibility.Visible;
                    textBox.Visibility = Visibility.Collapsed;

                    textBlock.Text = Text;
                    textBox.Text = Text;
                }
                else if (e.Key == Key.Enter)
                {
                    textBlock.Visibility = Visibility.Visible;
                    textBox.Visibility = Visibility.Collapsed;

                    Text = textBox.Text;
                }

                e.Handled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                textBlock.Visibility = Visibility.Visible;
                textBox.Visibility = Visibility.Collapsed;

                e.Handled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                textBlock.Visibility = Visibility.Visible;
                textBox.Visibility = Visibility.Collapsed;

                e.Handled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Text":
                    textBlock.Text = Text;
                    textBox.Text = Text;
                    break;

                case "FontSize":
                    textBlock.FontSize = FontSize;
                    textBox.FontSize = FontSize;
                    break;

                default:
                    break;
            }


            base.OnPropertyChanged(e);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            Debug.WriteLine(e.ClickCount);

            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                textBlock.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Visible;

                textBox.Focus();
            }

            base.OnMouseLeftButtonDown(e);
        }

        
    }
}
