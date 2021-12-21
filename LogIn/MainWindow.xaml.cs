
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace LogIn
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

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void LisOfUsers_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new Users.MainWindow().ShowDialog();
            try
            {
                ShowDialog();
            }
            catch
            {
                Close();
            }
        }
    }
}
