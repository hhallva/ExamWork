using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExamWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        public ShopPage()
        {
            InitializeComponent();

            UserFullnameLabel.Content = $"{App.Current.Resources["UserSurname"].ToString()} " +
                                         $"{App.Current.Resources["UserName"].ToString()} " +
                                         $"{App.Current.Resources["UserPatronymic"].ToString()}";
            CreateProductContainer();
        }

        private void ExitImage_MouseDown(object sender, RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new AuthorizationPage());
        }

        private void CartImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //необходимо реализовать переход в корзину
        }

        private void CreateProductContainer()
        {
            StackPanel productPanel = new()
            {
                
                Orientation = Orientation.Vertical,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBlock nameTextBlock = new()
            {
                Text = "Название",
                Width = this.Width * 0.85,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };

            TextBlock descriptionTextBlock = new()
            {
                Text = "Описание товара",
                Width = this.Width * 0.85,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 10,
            };

            TextBlock manufacturerTextBlock = new()
            {
                Text = "производитель",
                Width = this.Width * 0.85,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 10,
            };

            TextBlock priceTextBlock = new()
            {
                Text = "Цена: 999.99",
                HorizontalAlignment = HorizontalAlignment.Left
            };

            //Image productImage = new()
            //{
            //    Source = new()
            //    Width = 70,
            //    Height = 70,
            //    Margin = new Thickness(5),
            //    HorizontalAlignment = HorizontalAlignment.Right
            //};


            productPanel.Children.Add(nameTextBlock);
            MainStackPanel.Children.Add(productPanel);
        }
    }
}
