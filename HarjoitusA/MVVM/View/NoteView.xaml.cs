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
using System.Reflection;


namespace WPFharjoituksia.MVVM.View
{
    /// <summary>
    /// Interaction logic for NoteView.xaml
    /// </summary>
    public partial class NoteView : UserControl
    {
        public NoteView()
        {
            
            InitializeComponent();
            content.Text = Properties.Settings.Default.writtenText;
        }


        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = Properties.Resource.Document;
            dialog.DefaultExt = ".txt";
            dialog.Filter = Properties.Resource.Documents;

            bool? result = dialog.ShowDialog();
           
            if (result == true)
            {
                string filename = dialog.FileName;
                content.Text = File.ReadAllText(filename);
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(content, Properties.Resource.Printing);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = Properties.Resource.DocumentsS;

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                File.WriteAllText(filename, content.Text);
            }
        }
        private void Font_Click(object sender, RoutedEventArgs e)
        {
            double fontS;
            FontFamily fontF;

            Edit editwindow = new Edit();

            if (editwindow.ShowDialog() == true)
            {
                fontS = editwindow.sliderFontSize.Value;
                try
                {
                    fontF = (FontFamily)editwindow.ComboFonts.SelectedItem;
                }
                catch
                {
                    fontF = content.FontFamily;
                }

                content.FontSize = fontS;
                content.FontFamily = fontF;
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.writtenText = "";
            Properties.Settings.Default.Save();
        }
    }
}

