using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int distens = 25;
        private int top = 90;
        private int result = 0;
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            
            TextBox textInput = new TextBox();
            textInput.HorizontalAlignment = HorizontalAlignment.Left;
            textInput.VerticalAlignment = VerticalAlignment.Top;
            textInput.Height = 25;
            textInput.Width = 150;
            textInput.FontSize = 16;
            textInput.Margin = new Thickness(195, top, 0, 0);
            top += distens;
            gMain.Children.Add(textInput);
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in gMain.Children)
            {
                if (item is TextBox) 
                {
                    TextBox num = (TextBox)item;
                    try
                    {
                        result += int.Parse(num.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Введите только целочисленные значения и не оставляйте поля пустыми");
                        break;
                    }
                }
                lblResult.Content = result.ToString();
            }
            result = 0;
        }

        private void btnExample_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                MessageBox.Show("Хочешь закрыть меня? :<");
        }
        

    }
}
