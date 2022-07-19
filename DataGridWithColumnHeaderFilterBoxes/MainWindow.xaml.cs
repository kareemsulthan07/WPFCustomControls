using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DataGridWithColumnHeaderFilterBoxes
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

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            Debug.WriteLine($"Sorting {e.Column.SortDirection}");
        }
    }

    public class CustomTextBox : TextBox
    {
        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(CustomTextBox), new PropertyMetadata(string.Empty));



        public string PlaceholderIcon
        {
            get { return (string)GetValue(PlaceholderIconProperty); }
            set { SetValue(PlaceholderIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderIconProperty =
            DependencyProperty.Register("PlaceholderIcon", typeof(string), typeof(CustomTextBox), new PropertyMetadata(string.Empty));



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (Template.FindName("placeholderGrid", this) is Grid placeholderGrid)
            {
                placeholderGrid.Margin = new Thickness(this.Padding.Left + 3, 0, 0, 0);
            }

        }
    }
}
