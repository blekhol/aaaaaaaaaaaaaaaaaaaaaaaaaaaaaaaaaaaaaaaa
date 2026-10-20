using System.Diagnostics;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        StreamingPlatform platform = new StreamingPlatform();

        public MainWindow()
        {
            InitializeComponent();

            Beolvas();

            tartalom.ItemsSource = platform.Tartalmak;
        }

        void Beolvas()
        {
            string szoveg = new StreamReader("catalog.txt").ReadToEnd();

            string[] sorok = szoveg.Split("\n");

            var sorozatok = new Dictionary<string, List<Video>>();

            foreach (var line in sorok)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    string[] adatok = line.Split(";");

                    if (adatok[0].Trim().ToLower() == "film")
                    {
                        Video v = new Video(adatok[1].Trim(), Convert.ToInt32(adatok[2].Trim()));
                        Movie m = new Movie(v);
                        platform.AddContent(m);
                    } 
                    else if (adatok[0].Trim().ToLower() == "sorozat")
                    {
                        Video v = new Video(adatok[2].Trim(), Convert.ToInt32(adatok[3].Trim()));

                        string sorozatCim = adatok[1].Trim();

                        if (!sorozatok.ContainsKey(sorozatCim))
                        {
                            sorozatok[sorozatCim] = new List<Video>();
                        }
                        sorozatok[sorozatCim].Add(v);
                    }
                }
            }

            foreach(var elem in sorozatok)
            {
                Series s = new Series(elem.Key, elem.Value);
                platform.AddContent(s);
            }
        }
    }
}