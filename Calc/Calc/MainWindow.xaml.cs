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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stack<double> num = new Stack<double>();
        private char operations = ' ';
        private string lenquage;
        private StringBuilder displayString;

        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }
        //pl-PL
        private void Setup()
        {
            CultureInfo ci =  CultureInfo.CurrentCulture;
            lenquage = ci.Name;

            //Change button dot 
            if(lenquage == "pl-PL")
            {
                btn_dot.Content = ",";
            }
            else
            {
                btn_dot.Content = ".";
            }

            displayString = new StringBuilder("0");
            tbx_dysplay.Text = displayString.ToString();
        }

        private void Operations()
        {
            double temp;
            if (num == null || num.Count <2)
            {
                try
                {
                    if(lenquage == "pl-PL")
                    {
                        temp = Double.Parse(displayString.ToString().Replace(',', '.'));
                        num.Push(temp);
                    }
                    else
                    {
                        num.Push(Double.Parse(displayString.ToString()));
                    }
                }
                catch
                {
                    tbx_dysplay.Text = "Operations method wrong";
                }
                displayString.Clear();
                displayString.Append("0");
                tbx_dysplay.Text = displayString.ToString();
            }
            else
            {
                DoOperations();
            }
        }
        
        private void DoOperations()
        {
            if (num.Count == 2)
            {
                double result = 0;
                double num1, num2;
                num2 = num.Pop();
                num1 = num.Pop();
                num.Clear();
                switch (operations)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        break;
                    default:
                        break;
                }
                num.Push(result);
                displayString.Clear();
                displayString.Append(result.ToString());
                tbx_dysplay.Text = displayString.ToString();
            }
        }

        private void ChangeValue(string s)
        {
            if (displayString.Length < 17)
            {
                if (displayString.ToString() == "0")
                {
                    displayString.Clear();
                    displayString.Append(s);
                }
                else
                {
                    displayString.Append(s);
                }
                tbx_dysplay.Text = displayString.ToString();
            }
        }


        #region Buttons 0-9
        private void Btn_7_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("7");
        }

        private void Btn_8_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("8");
        }

        private void Btn_9_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("9");
        }

        private void Btn_6_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("6");
        }

        private void Btn_5_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("5");
        }

        private void Btn_4_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("4");
        }

        private void Btn_3_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("3");
        }

        private void Btn_2_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("2");
        }

        private void Btn_1_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("1");
        }

        private void Btn_0_Click(object sender, RoutedEventArgs e)
        {
            ChangeValue("0");
        }

        #endregion

        #region Buttons Clear
        private void Btn_ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            displayString.Clear();
            displayString.Append("0");
            tbx_dysplay.Text = displayString.ToString();
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            displayString.Clear();
            displayString.Append("0");
            tbx_dysplay.Text = displayString.ToString();
            num.Clear();
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if(displayString[0] == '-')
            {
                if(displayString.Length == 2)
                {
                    displayString.Clear();
                    displayString.Append("0");
                }
                else
                {
                    displayString.Remove(displayString.Length - 1, 1);
                }
            }
            else
            {
                if(displayString.Length > 1)
                {
                    displayString.Remove(displayString.Length - 1, 1);
                }
                else
                {
                    displayString.Clear();
                    displayString.Append("0");
                }
            }
            tbx_dysplay.Text = displayString.ToString();
        }

        #endregion

        #region Buttons operations
        private void Btn_div_Click(object sender, RoutedEventArgs e)
        {
            operations = '/';
            Operations();
        }

        private void Btn_mul_Click(object sender, RoutedEventArgs e)
        { 
            operations = '*';
            Operations();
        }

        private void Btn_minus_Click(object sender, RoutedEventArgs e)
        {
            operations = '-';
            Operations();
        }

        private void Btn_plus_Click(object sender, RoutedEventArgs e)
        {
            operations = '+';
            Operations();
        }

        private void Btn_eq_Click(object sender, RoutedEventArgs e)
        {
            Operations();
            DoOperations();
        }

        #endregion

        #region Buttons +- , 
        private void Btn_sign_Click(object sender, RoutedEventArgs e)
        {
            if(displayString.ToString() == "0")
            {

            }
            else if(displayString[0] != '-')
            {
                displayString.Insert(0,'-');
            }
            else if(displayString[0] == '-')
            {
                displayString.Remove(0, 1);
            }
            tbx_dysplay.Text = displayString.ToString();
        }

        private void Btn_dot_Click(object sender, RoutedEventArgs e)
        {
            if (displayString.ToString().Contains(',') || displayString.ToString().Contains(','))
            {

            }
            else
            {
                // pl add ,
                if(lenquage == "pl-PL")
                {
                    displayString.Append(',');
                }
                else
                {
                    displayString.Append('.');
                }
            }
            tbx_dysplay.Text = displayString.ToString();
        }
        #endregion
    }
}
