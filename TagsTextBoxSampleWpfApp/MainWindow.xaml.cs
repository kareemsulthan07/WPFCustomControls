using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TagsTextBoxSampleWpfApp
{
    public class Tag
    {
        public string Text { get; set; }
    }


    public partial class MainWindow : Window
    {
        private ItemsControl tagsItemsControl;
        private ObservableCollection<Tag> tags;


        public MainWindow()
        {
            InitializeComponent();

            tags = new ObservableCollection<Tag>();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tagsTextBox.Template.FindName("tagsItemsControl", tagsTextBox) is ItemsControl itemsControl)
                {
                    tagsItemsControl = itemsControl;
                    tagsItemsControl.ItemsSource = tags;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tagsTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.OemComma)
                {
                    if (!string.IsNullOrWhiteSpace(tagsTextBox.Text))
                    {
                        var _tag = new Tag()
                        {
                            Text = tagsTextBox.Text,
                        };
                        tags.Add(_tag);
                    }

                    tagsTextBox.Text = "";
                    e.Handled = true;
                }
                else if (e.Key == Key.Back)
                {
                    if (string.IsNullOrWhiteSpace(tagsTextBox.Text) && tags.Any())
                    {
                        var lastTag = tags.Last();
                        string text = lastTag.Text;

                        tags.Remove(lastTag);

                        tagsTextBox.Text = text;
                        tagsTextBox.CaretIndex = text.Length;

                        e.Handled = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var textBlock = (TextBlock)sender;
                if (textBlock.DataContext is Tag _tag)
                {
                    tags.Remove(_tag);
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}