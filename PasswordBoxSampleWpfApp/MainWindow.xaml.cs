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
using System.Diagnostics;

namespace PasswordBoxSampleWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void toggleButton_Checked(object sender, RoutedEventArgs e)
    {
        textBox.Visibility = Visibility.Visible;
        passwordBox.Visibility = Visibility.Collapsed;
    }

    private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
    {
        textBox.Visibility = Visibility.Collapsed;
        passwordBox.Visibility = Visibility.Visible;
    }

    private bool isUpdatingTextBox = false,
        isUpdatingPasswordBox = false;
    private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (isUpdatingPasswordBox) return;

        isUpdatingTextBox = true;
        textBox.Text = passwordBox.Password;
        isUpdatingTextBox = false;
    }

    private void textBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (isUpdatingTextBox) return;

        isUpdatingPasswordBox = true;
        passwordBox.Password = textBox.Text;
        isUpdatingPasswordBox = false;
    }
}