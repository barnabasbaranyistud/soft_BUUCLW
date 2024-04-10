using CsvHelper;
using System.ComponentModel;

namespace Ea7
{
    public partial class Form1 : Form
    {
        BindingList<CountryData> countryList = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = countryList;

            using (StreamReader sr = new StreamReader("C:\\Users\\barnabasbaranyi\\source\\repos\\soft_BUUCLW\\Ea7\\countries.csv"))
            {
                sr.ReadLine();

                while (sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] s = sor.Split(",");

                    CountryData countryData = new CountryData();
                    countryData.Name = s[0];
                    countryData.Population = long.Parse(s[1]);
                    countryData.AreaInSquareKm = double.Parse(s[2]);

                    countryList.Add(countryData);
                }


            }
        }
    }
}
