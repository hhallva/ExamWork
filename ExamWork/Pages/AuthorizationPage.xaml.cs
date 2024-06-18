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
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccessLayer.IsUserExist(loginTextBox.Text, passwordBox.Password))
            {
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
