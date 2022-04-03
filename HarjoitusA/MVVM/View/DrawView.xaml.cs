using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for DrawView.xaml
    /// </summary>
    public partial class DrawView : UserControl
    {
        public DrawView()
        {
            InitializeComponent();
        }



        private void Save_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)drawCanwas.ActualWidth, (int)drawCanwas.ActualHeight, 100.0, 100.0, PixelFormats.Default);
            bmp.Render(drawCanwas);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));

            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.DefaultExt = ".png";
            dialog.Filter = Properties.Resource.PngFiles;
            bool? result = dialog.ShowDialog();


            if (result == true)
            {
                string filename = dialog.FileName;
                FileStream stream = File.Create(filename);
                encoder.Save(stream);
                stream.Close();
            }
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            if (drawCanwas.Strokes.Count > 0)
            {
                drawCanwas.Strokes.Clear();
            }
        }

        private void black_Click(object sender, RoutedEventArgs e)
        {
            drawCanwas.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            drawCanwas.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void green_Click(object sender, RoutedEventArgs e)
        {
            drawCanwas.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void small_Click(object sender, RoutedEventArgs e)
        {
            drawCanwas.DefaultDrawingAttributes.Width = 2;
            drawCanwas.DefaultDrawingAttributes.Height = 2;
        }

        private void medium_Click(object sender, RoutedEventArgs e)
        {
            drawCanwas.DefaultDrawingAttributes.Width = 4;
            drawCanwas.DefaultDrawingAttributes.Height = 4;
        }

        private void large_Click(object sender, RoutedEventArgs e)
        {
            drawCanwas.DefaultDrawingAttributes.Width = 6;
            drawCanwas.DefaultDrawingAttributes.Height = 6;
        }

    }
}
