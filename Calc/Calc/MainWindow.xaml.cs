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
        private StringBuilder displayString;
        bool signOp;
        bool eq;

        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }
 
        private void Setup()
        {
            displayString = new StringBuilder("0");
            tbx_dysplay.Text = displayString.ToString();
        }

        private void Operations(char c)
        {
            if (!signOp)
            {
                if (Double.TryParse(displayString.ToString(), out double result))
                {
                    signOp = true;
                    num.Push(result);
                    DoOperations();
                }
            }
            operations = c;
            eq = false;
        }
        
        private void DoOperations()
        {
            if (num.Count == 2)
            {
                double result = 0.0;
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
                        else
                        {
                            tbx_dysplay.Text = "Nie dziel przez zero!";
                            return;
                        }
                        break;
                    default:
                        break;
                }

                num.Push(result);
                displayString.Clear();
                displayString.Append(result.ToString());
                tbx_dysplay.Text = displayString.ToString();
                displayString.Clear();
                signOp = false;
            }
        }

        private void ChangeValue(string s)
        {
            if (signOp)
            {
                displayString.Clear();
                displayString.Append("0");
                signOp = false;
            }
            if (eq)
            {
                num.Clear();
                signOp = false;
                eq = false;
            }
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
                eq = false;
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
            if (displayString.ToString() == "")
            {
                displayString.Append("0");
            }
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
            Operations('/');
        }

        private void Btn_mul_Click(object sender, RoutedEventArgs e)
        { 
            Operations('*');
        }

        private void Btn_minus_Click(object sender, RoutedEventArgs e)
        {
            Operations('-');
        }

        private void Btn_plus_Click(object sender, RoutedEventArgs e)
        {   
            Operations('+');
        }

        private void Btn_eq_Click(object sender, RoutedEventArgs e)
        {
            Operations(' ');
            eq = true;
            signOp = true;
        }

        #endregion

        #region Buttons +- , 
        private void Btn_sign_Click(object sender, RoutedEventArgs e)
        {
            if(displayString.ToString() == "0")
            {

            }
            else if(!displayString.ToString().Contains('-'))
            {
                displayString.Insert(0,'-');
            }
            else if(displayString.ToString().Contains('-'))
            {
                displayString.Remove(0, 1);
            }
            tbx_dysplay.Text = displayString.ToString();
        }

        private void Btn_dot_Click(object sender, RoutedEventArgs e)
        {
            if (!displayString.ToString().Contains(","))
            {
                displayString.Append(",");
            }
            tbx_dysplay.Text = displayString.ToString();
        }
        #endregion

        #region Input Keys
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.NumPad1 || e.Key == Key.D1) ChangeValue("1");
            else if (e.Key == Key.NumPad2 || e.Key == Key.D2) ChangeValue("2");
            else if (e.Key == Key.NumPad3 || e.Key == Key.D3) ChangeValue("3");
            else if (e.Key == Key.NumPad4 || e.Key == Key.D4) ChangeValue("4");
            else if (e.Key == Key.NumPad5 || e.Key == Key.D5) ChangeValue("5");
            else if (e.Key == Key.NumPad6 || e.Key == Key.D6) ChangeValue("6");
            else if (e.Key == Key.NumPad7 || e.Key == Key.D7) ChangeValue("7");
            else if (e.Key == Key.NumPad8 || e.Key == Key.D8) ChangeValue("8");
            else if (e.Key == Key.NumPad9 || e.Key == Key.D9) ChangeValue("9");
            else if (e.Key == Key.NumPad0 || e.Key == Key.D0) ChangeValue("0");
            else if (e.Key == Key.Decimal) ChangeValue(",");
           
            if (e.Key == Key.Multiply) Operations('*');
            else if (e.Key == Key.Divide) Operations('/');
            else if (e.Key == Key.Add) Operations('+');
            else if (e.Key == Key.Subtract) Operations('-');
            if (e.Key == Key.Enter) {
                Operations(' ');
                signOp = true;
                eq = true;
            }
           
        }
        #endregion
    }
}
