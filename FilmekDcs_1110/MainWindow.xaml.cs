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

namespace FilmekDcs_1110
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Film
        {
            public Film(string cim, string mufaj, int hossz, double ertekeles)
            {
                Cim = cim;
                Mufaj = mufaj;
                Hossz = hossz;
                Ertekeles = ertekeles;
            }

            public string Cim {  get; set; }
            public string Mufaj { get; set; }
            public int Hossz { get; set; }
            public double Ertekeles { get; set; }
        }
        public List<Film> filmek = new List<Film>()
            {
                new Film("Csillagok háborúja", "sci-fi", 121, 8.6),
                new Film("Titanic", "dráma", 195, 7.8),
                new Film("A Gyűrűk Ura", "fantasy", 201, 8.8),
                new Film("Mátrix", "sci-fi", 136, 8.7),
                new Film("Shrek", "animáció", 90, 7.9)
            };
        public MainWindow()
        {
            InitializeComponent();

        }

        private void filmekbetoltese(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = filmek;
            datagrid.Items.Refresh();
        }

        private void hanyfilmvan(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {filmek.Count()}db film van");
        }

        private void leghoszabbfilm(object sender, RoutedEventArgs e)
        {
            var leghoszabbf = filmek.OrderByDescending(f => f.Hossz).Take(1);
            datagrid.ItemsSource = leghoszabbf;
            datagrid.Items.Refresh();
        }

        private void atlagertekeles(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Filmek átlagos értékelése: {filmek.Average(f => f.Hossz)}");
        }

        private void csakscifi(object sender, RoutedEventArgs e)
        {
            var csaksc = filmek.Where(f => f.Mufaj.ToLower() == "sci-fi").ToList();
            datagrid.ItemsSource = csaksc;
            datagrid.Items.Refresh();
        }
    }
}