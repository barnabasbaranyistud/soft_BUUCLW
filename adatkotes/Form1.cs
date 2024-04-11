using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace adatkotes
{
    public partial class Form1 : Form
    {
        BindingList<CountryData> countryList = new BindingList<CountryData>();
        public Form1()
        {
            InitializeComponent();
            countryDataBindingSource.DataSource = countryList;
            dataGridView1.DataSource = countryDataBindingSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("european_countries.csv");
            var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            var tomb = csv.GetRecords<CountryData>();
            foreach (var item in tomb)
            {
                countryList.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            countryDataBindingSource.RemoveCurrent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCountryData fcd = new FormCountryData();
            fcd.CountryData = countryDataBindingSource.Current as CountryData;
            fcd.ShowDialog();
        }
    }
}