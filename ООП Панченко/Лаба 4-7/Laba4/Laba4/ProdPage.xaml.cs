using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Laba4.UserControl1;
using static MaterialDesignThemes.Wpf.Theme;
using Button = System.Windows.Controls.Button;

namespace Laba4
{
    public class MaxValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int[] prices && prices.Length > 0)
            {
                int maxValue = prices.Max();
                return string.Format(" - {0} BYN", maxValue);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public partial class ProdPage : Window
    {
        public ProdPage(ItemData selectedProduct)
        {
            try
            {
                InitializeComponent();
                DataContext = selectedProduct;

                for (int i = 0; i < selectedProduct.AddImageFilePath.Length; i++)
                {
                    Image image = new Image();
                    BitmapImage bitmapImage = new BitmapImage(new Uri(selectedProduct.AddImageFilePath[i]));
                    image.Source = bitmapImage;
                    image.Width = 270;
                    image.Margin = new Thickness(10);
                    wraForImages.Children.Add(image);
                }
                UserControl3 userControl = new();
                userControl.MaxTicketsAmount = selectedProduct.TicketCount.ToString();
                mainPanel.Children.Add(userControl);

                UserControl2 userControl2 = new();
                userControl2.RotationAngle = 170;
                infoStackPanel.Children.Add(userControl2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CommentControl_CommentSubmitted(object sender, CommentEventArgs e)
        {
            // Обработка отправленного комментария
            string name = e.Name;
            string comment = e.Comment;
            MessageBox.Show($"Комментарий от {name}: {comment}");
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainPage = new();
            mainPage.Show();

            Window currentWindow = Window.GetWindow(this);
            currentWindow.Close();
        }
    }
}