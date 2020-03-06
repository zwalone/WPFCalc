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
        private double num1;
        private double num2;
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

        private void ChangeValue(string s)
        {
            if (displayString.Length < 16)
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

        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Buttons + - / * +
        private void Btn_div_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_mul_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_minus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_plus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_eq_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Buttons +- , 
        private void Btn_sign_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_dot_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
