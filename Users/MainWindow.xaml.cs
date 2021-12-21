using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

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
            System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
            System.Windows.Application.Current.Shutdown();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private class UserData
        {

            public string Name { get; set; }

            public string Password { get; set; }
            public string Email { get; set; }
            public string Comment { get; set; }

        }
    }
}
