using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace ChatGPTWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Message> messages;


        public MainWindow()
        {
            InitializeComponent();

            messages = new ObservableCollection<Message>();

            messagesItemsControl.ItemsSource = messages;
        }

        private async void messageTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    if (string.IsNullOrWhiteSpace(messageTextBox.Text))
                        e.Handled = true;

                    if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        Debug.WriteLine("shift+enter key");

                        messageTextBox.Text = $"{messageTextBox.Text}\n";
                        messageTextBox.CaretIndex = messageTextBox.Text.Length;

                        e.Handled = true;
                        return;
                    }

                    var request = new Message()
                    {
                        IsRequest = true,
                        Text = messageTextBox.Text,
                    };
                    messages.Add(request);

                    messageTextBox.Text = "";
                    e.Handled = true;

                    await Task.Delay(2000);

                    var response = new Message()
                    {
                        IsRequest = false,
                        Text = $"ChatGPT Response:\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae diam non risus dignissim suscipit. Aliquam posuere cursus tellus non sagittis. Duis non augue vel dui fermentum placerat. Suspendisse porttitor nunc ut dapibus lacinia."
                    };

                    messages.Add(response);

                    messagesScrollViewer.ScrollToEnd();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void sendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(messageTextBox.Text))
                    return;

                var request = new Message()
                {
                    IsRequest = true,
                    Text = messageTextBox.Text,
                };
                messages.Add(request);

                messageTextBox.Text = "";

                await Task.Delay(2000);

                var response = new Message()
                {
                    IsRequest = false,
                    Text = $"ChatGPT Response:\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae diam non risus dignissim suscipit. Aliquam posuere cursus tellus non sagittis. Duis non augue vel dui fermentum placerat. Suspendisse porttitor nunc ut dapibus lacinia."
                };

                messages.Add(response);

                messagesScrollViewer.ScrollToEnd();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class Message : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _isRequest = false;

        public bool IsRequest
        {
            get { return _isRequest; }
            set { _isRequest = value; }
        }

        public string Text { get; set; }


        public Message()
        {
        }


        public override string ToString()
        {
            return Text;
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}