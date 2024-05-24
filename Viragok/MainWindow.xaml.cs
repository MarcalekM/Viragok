using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Viragok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Virag> viragok = new();
        public MainWindow()
        {
            InitializeComponent();
            using StreamReader sr = new(
                path: @"..\..\..\src\flowers.txt",
                encoding: System.Text.Encoding.UTF8);
            while (!sr.EndOfStream) viragok.Add(new(sr.ReadLine()));
            Feltolt(viragok);
        }

        private void Feltolt(List<Virag> viragok)
        {
            var v = viragok.OrderBy(v => v._nev).ToList();
            Viragok.Items.Clear();
            foreach (var vi in viragok)
            {
                ListBoxItem virag = new();
                virag.Content = vi._nev;
                Viragok.Items.Add(virag);
            }
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            if (Viragok.Items.Count != 0)
            {
                ListBoxItem copiedItem = (ListBoxItem)Viragok.SelectedItem;
                string x = copiedItem.Content.ToString();
                Masolatok.Items.Add(x);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)Viragok.SelectedItem;
            int i = -1;
            foreach (var v in viragok)
            {
                if (v._nev == item.Content.ToString())
                {
                    i = viragok.IndexOf(v);
                }
            }
            if (i > -1) viragok.RemoveAt(i);
            Feltolt(viragok);
            Adatok.Text = string.Empty;
        }

        private void Viragok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Viragok.SelectedItem != null)
            {
                ListBoxItem virag = (ListBoxItem)Viragok.SelectedItem;
                foreach (var v in viragok)
                {
                    if (v._nev == virag.Content.ToString())
                    {
                        Adatok.Text = $"Adatok:\nÁr: {v._ar.ToString()} Ft\nSzín: {v._szin.ToString()}";
                    }
                }
            }
        }
    }
}