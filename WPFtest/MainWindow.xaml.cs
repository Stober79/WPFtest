
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;


namespace WPFtest
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public static class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }
    public partial class MainWindow : Window
    {
        public UserData userData = new UserData();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            AssignData();
            bool isEmailCorrect = ValidatorExtensions.IsValidEmailAddress(userData.Email);
            if (isEmailCorrect)
            {              
                if (ValidateData())
                {

                    var json = JsonConvert.SerializeObject(userData);
                    Name.Clear();
                    Password.Clear();
                    Email.Clear();
                    Comment.Clear();
                    File.WriteAllText(@"D:\"+userData.Name+".txt", json);
                    MessageBox.Show("User Data was saved successfully.");
                }
            }
            else
            {
                MessageBox.Show("Inccorect email address.");
            }
        }
        private bool ValidateData()
        {
            var validationContext = new ValidationContext(userData);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(userData, validationContext, results, true))
            {
                return true;
            }
            foreach (var result in results)
            {
                MessageBox.Show(result.ErrorMessage);
            }
            return false;

        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AssignData();
            if (File.Exists(@"D:\"+userData.Name+".txt"))
            {                
                if(AreCretentialsCorrect(@"D:\" + userData.Name + ".txt"))
                {
                    MessageBox.Show("You are logedd in");
                    LogIn.MainWindow logIn = new LogIn.MainWindow();
                    this.Close();
                    logIn.Show();
                }
                else
                {
                    MessageBox.Show("Credentials are inccorect");
                }
            }
            else
            {
                MessageBox.Show("This user does not exist.");
            }

        }
        private void AssignData()
        {
            userData.Name = Name.Text;
            userData.Password = Password.Password.ToString();
            userData.Email = Email.Text;
            userData.Comment = Comment.Text;

        }
        private bool AreCretentialsCorrect(string filePath)
        {
            var newJson = JsonConvert.SerializeObject(userData);
            string savedUserData = File.ReadAllText(filePath);
            bool correctName = JToken.Equals(newJson[0], savedUserData[0]);
            bool correctPassword = JToken.Equals(newJson[1], savedUserData[1]);
            return correctName && correctPassword;
        }
    }
}
