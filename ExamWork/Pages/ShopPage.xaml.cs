﻿using ExamWork.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DAL = ExamWork.Classes.DataAccessLayer;

namespace ExamWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        internal List<Product> Products { get; set; }
        public string SortQuery { get; set; }

        public ShopPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Вывод ФИО на страницу
            UserFullnameLabel.Content = $"{App.Current.Resources["UserSurname"].ToString()} " +
                                         $"{App.Current.Resources["UserName"].ToString()} " +
                                         $"{App.Current.Resources["UserPatronymic"].ToString()}";

            SortComboBox.SelectionChanged += FilterComboBox_SelectionChanged;
            DiscountFilterComboBox.SelectionChanged += FilterComboBox_SelectionChanged;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;

            

            Products = DAL.GetProductsData(SortQuery);
            foreach (Product product in Products)
            {
                CreateProductContainer(product);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //обработка изменения строки поиска
        }

        private void ExitImage_MouseDown(object sender, RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new AuthorizationPage());
        }

        private void CartImage_MouseDown(object sender, MouseButtonEventArgs e)
        {

            //необходимо реализовать переход в корзину
        }

        private void CreateProductContainer(Product product)
        {
            Border border = new()
            {
                Height = 130,
                Background = new SolidColorBrush(Color.FromArgb(255, 224, 223, 223)),
                Margin = new Thickness(10)
            };

            StackPanel stackPanel1 = new()
            {
                Margin = new Thickness(10),
            };

            Grid grid = new Grid();

            StackPanel stackPanel2 = new();

            Label nameProductLabel = new()
            {
                Content = product.Name,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 16
            };

            Label manufacturerProductLabel = new()
            {
                Content = product.Manufacturer,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(0, -10, 0, 0),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 152, 144, 144))
            };

            Label вescriptionLabel = new()
            {
                Content = product.Description,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            StackPanel stackPanel3 = new()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, -5, 0, 0),
            };

            Label textLabel = new()
            {
                Content = "Цена:",
                FontSize = 16
            };

            TextBlock discounCostTextBlock = new()
            {
                Text = Math.Round(product.Cost - (product.Cost * product.DiscountAmount * 0.01), 2).ToString(),
                Height = 20,
                FontSize = 18
            };

            Border imageBorder = new()
            {
                Background = new SolidColorBrush(Color.FromArgb(255, 206, 194, 194)),
                Height = 100,

            };

            Image image = new()
            {
                Source = new BitmapImage(new Uri("/Images/product.png", UriKind.Relative))
            };

            MainStackPanel.Children.Add(border);
            border.Child = stackPanel1;

            stackPanel1.Children.Add(grid);
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            grid.Children.Add(stackPanel2);
            stackPanel2.Children.Add(nameProductLabel);
            stackPanel2.Children.Add(manufacturerProductLabel);
            stackPanel2.Children.Add(вescriptionLabel);
            stackPanel2.Children.Add(stackPanel3);

            stackPanel3.Children.Add(textLabel);
            stackPanel3.Children.Add(discounCostTextBlock);
            if (product.DiscountAmount > 0)
            {
                TextBlock CostTextBlock = new()
                {
                    Text = product.Cost.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontSize = 16,
                    TextDecorations = TextDecorations.Strikethrough,
                    Foreground = new SolidColorBrush(Color.FromArgb(255, 93, 93, 93))
                };

                Label discountLabel = new()
                {
                    Content = $"-{product.DiscountAmount}%",
                    FontSize = 40,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 10, 5),
                    Background = new SolidColorBrush((product.DiscountAmount < 15) ? Colors.White : Colors.Chartreuse),
                };

                stackPanel3.Children.Add(CostTextBlock);
                grid.Children.Add(discountLabel);
                Grid.SetColumn(discountLabel, 1);
            }

            imageBorder.Child = image;
            grid.Children.Add(imageBorder);

            Grid.SetColumn(stackPanel2, 0);
            Grid.SetColumn(imageBorder, 2);
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sortQuery = string.Empty;
            string discountQuery = string.Empty;

            switch (SortComboBox.SelectedIndex)
            {
                case 0:
                    sortQuery = "ORDER BY ProductCost ASC";
                    break;
                case 1:
                    sortQuery = "ORDER BY ProductCost DESC";
                    break;
            }

            switch (DiscountFilterComboBox.SelectedIndex)
            {
                case 0:
                    discountQuery = "";
                    break;
                case 1:
                    discountQuery = "WHERE ProductDiscountAmount BETWEEN 0 AND 9.99";
                    break;
                case 2:
                    discountQuery = "WHERE ProductDiscountAmount BETWEEN 10 AND 14.99";
                    break;
                case 3:
                    discountQuery = "WHERE ProductDiscountAmount BETWEEN 15 AND 100";
                    break;
            }

            SortQuery = $"{discountQuery} {sortQuery}";
        }
    }
}
