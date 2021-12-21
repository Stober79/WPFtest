
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using UserModel;


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
        public UserData userData { get; set; }
        public static List<UserData> ListOfUsers = new List<UserData>();
        public MainWindow()
        {
            InitializeComponent();
            ListOfUsers = UsersJson();
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = AssignData();
            bool isEmailCorrect = ValidatorExtensions.IsValidEmailAddress(userData.Email);

            if (isEmailCorrect)
            {
                if (ValidateData())
                {
                    ListOfUsers.Add(currentUser);
                    var json = JsonConvert.SerializeObject(ListOfUsers);
                    Name.Clear();
                    Password.Clear();
                    Email.Clear();
                    Comment.Clear();
                    File.WriteAllText(@"D:\users.txt", String.Empty);
                    File.AppendAllText(@"D:\users.txt", json);
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
            if (File.Exists(@"D:\users.txt"))
            {                
                if(IsUserCredentialsCorrect())
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
        private UserData AssignData()
        {
            userData = new UserData();  
            userData.Name = Name.Text;
            userData.Password = Password.Password.ToString();
            userData.Email = Email.Text;
            userData.Comment = Comment.Text;
            return userData;

        }
        private bool IsUserCredentialsCorrect()
        {
            var newJson = JsonConvert.SerializeObject(userData);
            var listOfUsers = UsersJson();
            bool result= false;
            foreach(var user in listOfUsers)
            {
                if(user.Name== userData.Name && user.Password == userData.Password)
                {
                    result = true;
                }
            }
            return result;  

        }
        public  List<UserData>  UsersJson()
        {
            if (File.Exists(@"D:\users.txt"))
            {
                string json = File.ReadAllText(@"D:\users.txt");
                return JsonConvert.DeserializeObject<List<UserData>>(json);
            }
            else
            {
                File.Create(@"D:\users.txt");
                List<UserData> currentList = new List<UserData>();
                return currentList;
            }
        }
    }
}
