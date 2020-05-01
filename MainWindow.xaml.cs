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

        private int result = 0;
        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {

            TextBox textInput = new TextBox()
            {
                Height = 25,
                Width = 150,
                FontSize = 16,
            };
            textInput.TextChanged += TextInput_TextChanged;
            spMain.Children.Add(textInput);
        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var item in spMain.Children)
            {
                if (item is TextBox num)
                {
                    try
                    {
                        result += int.Parse(num.Text);
                    }
                    catch
                    {
                        if (num.Text == "") { }
                        else
                        {
                            MessageBox.Show("Введите только целочисленные значения");
                            break;
                        }
                    }
                }
                lblResult.Content = result.ToString();
            }
            result = 0;
        }

        private void BtnExample_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                MessageBox.Show("Хочешь закрыть меня? :<");
        }
    }
}
