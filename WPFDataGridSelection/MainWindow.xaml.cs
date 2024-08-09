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

namespace WPFDataGridSelection
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

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class Persons : List<Person>
    {
        public Persons()
        {
            Add(new Person { FirstName = "John", LastName = "Doe", AddressLine1 = "123 Main St", AddressLine2 = "Apt 101", PhoneNumber = "123-456-7890", Email = "john.doe@example.com" });
            Add(new Person { FirstName = "Jane", LastName = "Smith", AddressLine1 = "456 Elm St", AddressLine2 = "", PhoneNumber = "987-654-3210", Email = "jane.smith@example.com" });
            Add(new Person { FirstName = "Bob", LastName = "Johnson", AddressLine1 = "789 Oak St", AddressLine2 = "Suite 202", PhoneNumber = "555-123-4567", Email = "bob.johnson@example.com" });
            Add(new Person { FirstName = "Alice", LastName = "Williams", AddressLine1 = "901 Maple St", AddressLine2 = "", PhoneNumber = "111-222-3333", Email = "alice.williams@example.com" });
            Add(new Person { FirstName = "Mike", LastName = "Davis", AddressLine1 = "234 Pine St", AddressLine2 = "Apt 303", PhoneNumber = "444-555-6666", Email = "mike.davis@example.com" });
            Add(new Person { FirstName = "Emma", LastName = "Taylor", AddressLine1 = "567 Cedar St", AddressLine2 = "", PhoneNumber = "777-888-9999", Email = "emma.taylor@example.com" });
            Add(new Person { FirstName = "Oliver", LastName = "Brown", AddressLine1 = "890 Walnut St", AddressLine2 = "Suite 101", PhoneNumber = "222-333-4444", Email = "oliver.brown@example.com" });
            Add(new Person { FirstName = "Sophia", LastName = "Jones", AddressLine1 = "345 Spruce St", AddressLine2 = "", PhoneNumber = "666-777-8888", Email = "sophia.jones@example.com" });
            Add(new Person { FirstName = "William", LastName = "Garcia", AddressLine1 = "678 Fir St", AddressLine2 = "Apt 202", PhoneNumber = "888-999-0000", Email = "william.garcia@example.com" });
            Add(new Person { FirstName = "Charlotte", LastName = "Harris", AddressLine1 = "901 Ash St", AddressLine2 = "", PhoneNumber = "000-111-2222", Email = "charlotte.harris@example.com" });
            Add(new Person { FirstName = "Thomas", LastName = "Martin", AddressLine1 = "234 Birch St", AddressLine2 = "Suite 303", PhoneNumber = "333-444-5555", Email = "thomas.martin@example.com" });
            Add(new Person { FirstName = "Abigail", LastName = "Thompson", AddressLine1 = "567 Cherry St", AddressLine2 = "", PhoneNumber = "555-666-7777", Email = "abigail.thompson@example.com" });
            Add(new Person { FirstName = "James", LastName = "White", AddressLine1 = "890 Cypress St", AddressLine2 = "Apt 101", PhoneNumber = "777-888-9999", Email = "james.white@example.com" });
            Add(new Person { FirstName = "Evelyn", LastName = "Patel", AddressLine1 = "345 Eucalyptus St", AddressLine2 = "", PhoneNumber = "999-000-1111", Email = "evelyn.patel@example.com" });
            Add(new Person { FirstName = "George", LastName = "Lee", AddressLine1 = "678 Banyan St", AddressLine2 = "Suite 202", PhoneNumber = "111-222-3333", Email = "george.lee@example.com" });
        }
    }
}