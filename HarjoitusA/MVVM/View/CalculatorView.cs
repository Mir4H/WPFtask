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

namespace WPFharjoituksia.MVVM.View
{
    /// <summary>
    /// Interaction logic for DiscoveryView.xaml
    /// </summary>
    public partial class CalculatorView : UserControl
    {
        string first_number;
        string second_number;
        string operation;
        double result;

        public CalculatorView()
        {
            InitializeComponent();
            first_number = "";
            second_number = "";
            operation = "";
        }


        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string button = ((Button)sender).Content.ToString();

            if (operation == "")
            {
                first_number += button;
                display.Text = first_number;
            }
            else
            {
                second_number += button;
                display.Text = first_number + operation + second_number;
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            string button = ((Button)sender).Content.ToString();

            if (first_number == "")
            {
                display.Text = Properties.Resource.firstnumb;
            } 
            else
            {
                second_number = "";
                operation = button;
                display.Text = first_number + operation;
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int num1 = 0;
            int num2 = 0;

            try
            {
                num1 = int.Parse(first_number);
                num2 = int.Parse(second_number);
            } catch {
                
                first_number = "";
                second_number = "";
                operation = "";
                result = 0;
            }


            if (second_number == "0" && operation == "/")
            {
                display.Text = Properties.Resource.zero;
                first_number = "";
                second_number = "";
                operation = "";
                result = 0;
            }



            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    display.Text = result.ToString();
                    break;

                case "-":
                    result = num1 - num2;
                    display.Text = result.ToString();
                    break;

                case "*":
                    result = num1 * num2;
                    display.Text = result.ToString();
                    break;

                case "/":
                    result = (double)num1 / (double)num2;
                    display.Text = result.ToString();
                    break;
            }
            operation = "";
            if (result != 0)
                first_number = result.ToString();
            else
                first_number = "";
        

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            first_number = "";
            second_number = "";
            operation = "";
            result = 0;
            display.Text = "0";
        }
    }
}

