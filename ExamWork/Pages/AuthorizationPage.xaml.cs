using ExamWork.Classes;
using System.Windows;
using System.Windows.Controls;

namespace ExamWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public delegate void SendUser(User user);

        public static event SendUser onUserSend;

        public AuthorizationPage()
        {
            InitializeComponent();

            //Логинов Федот Святославович
            loginTextBox.Text = "loginDEgtt2018";
            passwordBox.Password = "7YD|BR";
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccessLayer.IsUserExist(loginTextBox.Text, passwordBox.Password))
            {
                onUserSend(DataAccessLayer.GetUserData(loginTextBox.Text, passwordBox.Password)); 
                App.CurrentFrame.Navigate(new ShopPage());
            }
            else
            {
                MessageBox.Show("Пользователь не может быть авторизован. \nЛогин или пароль введены неверно.",
                                "Сообщение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }


        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new ShopPage());
        }
    }
}
