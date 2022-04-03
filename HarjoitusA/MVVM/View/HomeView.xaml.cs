using Microsoft.Win32;
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
using System.IO;
using System.Runtime.CompilerServices;

namespace WPFharjoituksia.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            if (Properties.Settings.Default.muisti1 == "")
                SetHidden(lappu1, poista1, muisti1);
            if (Properties.Settings.Default.muisti2 == "")
                SetHidden(lappu2, poista2, muisti2);
            if (Properties.Settings.Default.muisti3 == "")
                SetHidden(lappu3, poista3, muisti3);
            if (Properties.Settings.Default.muisti4 == "")
                SetHidden(lappu4, poista4, muisti4);
            if (Properties.Settings.Default.muisti5 == "")
                SetHidden(lappu5, poista5, muisti5);
            if (Properties.Settings.Default.muisti6 == "")
                SetHidden(lappu6, poista6, muisti6);
            AllFull();
        }

        private void AllFull()
        {
            if (lappu1.Visibility == Visibility.Visible &&
                lappu2.Visibility == Visibility.Visible &&
                lappu3.Visibility == Visibility.Visible &&
                lappu4.Visibility == Visibility.Visible &&
                lappu5.Visibility == Visibility.Visible &&
                lappu6.Visibility == Visibility.Visible)
            {
                lisaa.Visibility = Visibility.Hidden;
            }
            else
            {
                lisaa.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (muisti1.Visibility == Visibility.Hidden)
                SetVisible(lappu1, poista1, muisti1);
            else if (muisti2.Visibility == Visibility.Hidden)
                SetVisible(lappu2, poista2, muisti2);
            else if (muisti3.Visibility == Visibility.Hidden)
                SetVisible(lappu3, poista3, muisti3);
            else if (muisti4.Visibility == Visibility.Hidden)
                SetVisible(lappu4, poista4, muisti4);
            else if (muisti5.Visibility == Visibility.Hidden)
                SetVisible(lappu5, poista5, muisti5);
            else if (muisti6.Visibility == Visibility.Hidden)
                SetVisible(lappu6, poista6, muisti6);
            AllFull();
        }

        private void SetVisible(Border lappu, Button poista, TextBox muisti)
        {
            lappu.Visibility = Visibility.Visible;
            poista.Visibility = Visibility.Visible;
            muisti.Visibility = Visibility.Visible;
        }

        private void poista1_Click(object sender, RoutedEventArgs e)
        {
            SetHidden(lappu1, poista1, muisti1);
            muisti1.Text = "";
            Properties.Settings.Default.muisti1 = muisti1.Text;
            Properties.Settings.Default.Save();
            AllFull();
        }

        private void poista2_Click(object sender, RoutedEventArgs e)
        {
            SetHidden(lappu2, poista2, muisti2);
            muisti2.Text = "";
            Properties.Settings.Default.muisti2 = muisti2.Text;
            Properties.Settings.Default.Save();
            AllFull();
        }
        private void poista3_Click(object sender, RoutedEventArgs e)
        {
            SetHidden(lappu3, poista3, muisti3);
            muisti3.Text = "";
            Properties.Settings.Default.muisti3 = muisti3.Text;
            Properties.Settings.Default.Save();
            AllFull();
        }

        private void poista4_Click(object sender, RoutedEventArgs e)
        {
            SetHidden(lappu4, poista4, muisti4);
            muisti4.Text = "";
            Properties.Settings.Default.muisti4 = muisti4.Text;
            Properties.Settings.Default.Save();
            AllFull();
        }
        private void poista5_Click(object sender, RoutedEventArgs e)
        {
            SetHidden(lappu5, poista5, muisti5);
            muisti5.Text = "";
            Properties.Settings.Default.muisti5 = muisti5.Text;
            Properties.Settings.Default.Save();
            AllFull();
        }
        private void poista6_Click(object sender, RoutedEventArgs e)
        {
            SetHidden(lappu6, poista6, muisti6);
            muisti6.Text = "";
            Properties.Settings.Default.muisti6 = muisti6.Text;
            Properties.Settings.Default.Save();
            AllFull();
        }

        private static void SetHidden(Border lappu, Button poista, TextBox muisti)
        {
            lappu.Visibility = Visibility.Hidden;
            poista.Visibility = Visibility.Hidden;
            muisti.Visibility = Visibility.Hidden;
        }

        private void muisti1_KeyUp(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.muisti1 = muisti1.Text;
            Properties.Settings.Default.Save();
        }
        private void muisti2_KeyUp(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.muisti2 = muisti2.Text;
            Properties.Settings.Default.Save();
        }
        private void muisti3_KeyUp(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.muisti3 = muisti3.Text;
            Properties.Settings.Default.Save();
        }
        private void muisti4_KeyUp(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.muisti4 = muisti4.Text;
            Properties.Settings.Default.Save();
        }
        private void muisti5_KeyUp(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.muisti5 = muisti5.Text;
            Properties.Settings.Default.Save();
        }
        private void muisti6_KeyUp(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.muisti6 = muisti6.Text;
            Properties.Settings.Default.Save();
        }



        private void muisti1_Loaded(object sender, RoutedEventArgs e)
        {
            muisti1.Text = Properties.Settings.Default.muisti1;
        }
        private void muisti2_Loaded(object sender, RoutedEventArgs e)
        {
            muisti2.Text = Properties.Settings.Default.muisti2;
        }
        private void muisti3_Loaded(object sender, RoutedEventArgs e)
        {
            muisti3.Text = Properties.Settings.Default.muisti3;
        }
        private void muisti4_Loaded(object sender, RoutedEventArgs e)
        {
            muisti4.Text = Properties.Settings.Default.muisti4;
        }
        private void muisti5_Loaded(object sender, RoutedEventArgs e)
        {
            muisti5.Text = Properties.Settings.Default.muisti5;
        }
        private void muisti6_Loaded(object sender, RoutedEventArgs e)
        {
            muisti6.Text = Properties.Settings.Default.muisti6;
        }

    }
}
