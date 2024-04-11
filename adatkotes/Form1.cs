using System.ComponentModel;

namespace adatkotes
{
    public partial class Form1 : Form
    {
        BindingList<CountryData> countryList = new BindingList<CountryData>();
        public Form1()
        {
            InitializeComponent();
        }
    }
}