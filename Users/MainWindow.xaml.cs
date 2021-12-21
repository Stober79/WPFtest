using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Navigation;
using UserModel;

namespace Users
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {   
            InitializeComponent();

            string json = File.ReadAllText(@"D:\users.txt");
            var currentUserList = JsonConvert.DeserializeObject<List<UserData>>(json);
            lvUsers.ItemsSource = currentUserList;
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
          DialogResult = false;
        }
    }
}
