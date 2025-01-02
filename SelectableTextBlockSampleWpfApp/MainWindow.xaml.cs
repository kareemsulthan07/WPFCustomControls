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

namespace SelectableTextBlockSampleWpfApp
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

    public class SelectableTextBlock : TextBox
    {
        public bool IsTextSelectionEnabled
        {
            get { return (bool)GetValue(IsTextSelectionEnabledProperty); }
            set { SetValue(IsTextSelectionEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsTextSelectionEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTextSelectionEnabledProperty =
            DependencyProperty.Register("IsTextSelectionEnabled", typeof(bool), typeof(SelectableTextBlock), new PropertyMetadata(false));


        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property.Name == nameof(IsTextSelectionEnabled))
            {
                var isTextSelectionEnabled = (bool)e.NewValue;
                if (isTextSelectionEnabled)
                {
                    TextWrapping = TextWrapping.Wrap;
                    IsReadOnly = true;
                    VerticalContentAlignment = VerticalAlignment.Top;
                    HorizontalContentAlignment = HorizontalAlignment.Left;
                    BorderThickness = new Thickness(0);
                }
                else
                {
                    TextWrapping = TextWrapping.NoWrap;
                    IsReadOnly = false;
                    VerticalContentAlignment = VerticalAlignment.Center;
                    HorizontalContentAlignment = HorizontalAlignment.Left;
                    BorderThickness = new Thickness(1);
                }
            }
        }

    }
}