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
            var v = viragok.OrderBy(v => v._nev).ToList();
            Feltolt(v);
        }

        private void Feltolt(List<Virag> viragok)
        {
            Viragok.Items.Clear();
            foreach (var v in viragok)
            {
                ListBoxItem virag = new();
                virag.Content = v._nev;
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
    }
}