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

        private double result = 0;
        public Dictionary<TextBox, ComboBox> Pair = new Dictionary<TextBox, ComboBox>();
        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            TextBox textInput = new TextBox()
            {
                Height = 25,
                Width = 150,
                FontSize = 16,
            };
            ComboBox operations = MakeComboBox(new string[] { "+", "-", "*", "/" });

            StackPanel stTextOper = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Orientation = Orientation.Horizontal
            };        

            Pair.Add(textInput, operations);
            textInput.TextChanged += TextInput_TextChanged;
            operations.SelectionChanged += SelectCombox_Changed;
            stTextOper.Children.Add(operations);
            stTextOper.Children.Add(textInput);
            spMain.Children.Add(stTextOper);
            textInput.Focus();
        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var stack in spMain.Children)
            {
                if(stack is StackPanel st)
                {
                    foreach (var item in st.Children)
                    {
                        if (item is TextBox num)
                        {
                            try
                            {
                                result = Count(result, double.Parse(num.Text), Pair[num].Text);
                            }
                            catch
                            {
                                if (num.Text == "") { }
                                else
                                {
                                    MessageBox.Show("Вводите только числа");
                                    break;
                                }
                            }
                        }
                        lblResult.Content = result.ToString();
                    }                    
                }
            }
            result = 0;
        }
        private void SelectCombox_Changed(object sender, SelectionChangedEventArgs e)
        {
            foreach (var stack in spMain.Children)
            {
                if (stack is StackPanel st)
                {
                    foreach (var item in st.Children)
                    {
                        if (item is TextBox num)
                        {
                            try
                            {
                                result = Count(result, double.Parse(num.Text), Pair[num].Text);
                            }
                            catch
                            {
                                if (num.Text == "") { }
                                else
                                {
                                    MessageBox.Show("Вводите только числа");
                                    break;
                                }
                            }
                        }
                        lblResult.Content = result.ToString();
                    }
                }
            }
            result = 0;
        }

        private void BtnExample_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                MessageBox.Show("Хочешь закрыть меня? :<");
        }
        private double Count(double result, double a, string op)
        {
            switch (op)
            {
                case "+":
                    result += a;
                    break;
                case "-":
                    result -= a;
                    break;
                case "*":
                    result *= a;
                    break;
                case "/":
                    result /= a;
                    break;
            }
            return result;
        }
        private ComboBox MakeComboBox(string[] arr)
        {
            ComboBox box = new ComboBox();
            foreach (string item in arr)
            {
                ComboBoxItem cbItem = new ComboBoxItem
                {
                    Content = item
                };
                box.Items.Add(cbItem);
            }
            return box;
        }
    }
}
