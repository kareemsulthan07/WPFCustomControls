using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Diagnostics.Debug;



namespace ExtendedListView_Reordering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> items;

        public MainWindow()
        {
            InitializeComponent();

            items = new ObservableCollection<string>()
            {
                "item 01",
                "item 02",
                "item 03",
                "item 04",
                "item 05",
                "item 06",
                "item 07",
                "item 08",
                "item 09",
                "item 10",
            };

            itemsListView.ItemsSource = items;
        }

        private void ListViewItem_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                // start drag
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    ListViewItem sourceListViewItem = (ListViewItem)sender;
                    DragDrop.DoDragDrop(itemsListView, sourceListViewItem, DragDropEffects.Move);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ListViewItem_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                var targetListViewItem = (ListViewItem)sender;
                var sourceListViewItem = (ListViewItem)e.Data.GetData("System.Windows.Controls.ListViewItem");

                if (sourceListViewItem == targetListViewItem)
                    return;

                var targetItem = targetListViewItem.Content.ToString();
                var sourceItem = sourceListViewItem.Content.ToString();

                var targetItemIndex = items.IndexOf(targetItem);
                var sourceItemIndex = items.IndexOf(sourceItem);

                Rectangle topRectangle = (Rectangle)targetListViewItem.Template.FindName("topRectangle", targetListViewItem);
                Rectangle bottomRectangle = (Rectangle)targetListViewItem.Template.FindName("bottomRectangle", targetListViewItem);

                if (targetItemIndex < sourceItemIndex)
                {
                    topRectangle.Visibility = Visibility.Visible;
                }
                else if (targetItemIndex > sourceItemIndex)
                {
                    bottomRectangle.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ListViewItem_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                // not useful
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ListViewItem_DragLeave(object sender, DragEventArgs e)
        {
            try
            {
                var targetListViewItem = (ListViewItem)sender;

                Rectangle topRectangle = (Rectangle)targetListViewItem.Template.FindName("topRectangle", targetListViewItem);
                Rectangle bottomRectangle = (Rectangle)targetListViewItem.Template.FindName("bottomRectangle", targetListViewItem);

                topRectangle.Visibility = Visibility.Collapsed;
                bottomRectangle.Visibility = Visibility.Collapsed;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ListViewItem_Drop(object sender, DragEventArgs e)
        {
            try
            {
                var targetListViewItem = (ListViewItem)sender;
                var sourceListViewItem = (ListViewItem)e.Data.GetData("System.Windows.Controls.ListViewItem");

                var targetItem = targetListViewItem.Content.ToString();
                var sourceItem = sourceListViewItem.Content.ToString();

                var targetItemIndex = items.IndexOf(targetItem);
                var sourceItemIndex = items.IndexOf(sourceItem);

                Rectangle topRectangle = (Rectangle)targetListViewItem.Template.FindName("topRectangle", targetListViewItem);
                Rectangle bottomRectangle = (Rectangle)targetListViewItem.Template.FindName("bottomRectangle", targetListViewItem);

                topRectangle.Visibility = Visibility.Collapsed;
                bottomRectangle.Visibility = Visibility.Collapsed;

                // important line
                items.Move(sourceItemIndex, targetItemIndex);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
