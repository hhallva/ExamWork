using ExamWork.Classes;
using DAL = ExamWork.Classes.DataAccessLayer;
using System.Windows;
using System.Windows.Controls;

namespace ExamWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();

            //Значения для теста В КОНЦЕ УБРАТЬ
            loginTextBox.Text = "loginDEmgu2018";
            passwordBox.Password = "0gC3bk";
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (DAL.IsUserExist(loginTextBox.Text, passwordBox.Password))
            {
                User user = DAL.GetUserData(loginTextBox.Text, passwordBox.Password);
                AcceptUserData(user);

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
            User user = new();
            AcceptUserData(user);

            App.CurrentFrame.Navigate(new ShopPage());
        }

        private static void AcceptUserData(User user)
        {
            App.Current.Resources["UserName"] = user.Name;
            App.Current.Resources["UserSurname"] = user.Surname;
            App.Current.Resources["UserPatronymic"] = user.Patronymic;
            App.Current.Resources["UserLogin"] = user.Login;
            App.Current.Resources["UserPassword"] = user.Password;
            App.Current.Resources["RoleID"] = user.RoleID;
        }
    }
}
