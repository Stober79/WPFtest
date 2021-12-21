
using System.Windows;
using System.Windows.Forms;



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
            System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
            System.Windows.Application.Current.Shutdown();
        }

        private void LisOfUsers_Click(object sender, RoutedEventArgs e)
        {

            Users.MainWindow users = new Users.MainWindow();
            this.Close();
            users.Show();
        }
    }
}
