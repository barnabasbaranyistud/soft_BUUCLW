using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace ZH2_ea
{
    public partial class Form1 : Form
    {
        BindingList<Fut�k> fut�k = new();
        public Form1()
        {
            InitializeComponent();
            ///dataGridView1.DataSource = fut�k; ///!!!!!!!!!!!!!!!!!BINDING SOURCE UT�N T�R�LNI, ADDIG J�
            fut�kBindingSource.DataSource = fut�k;

        }

        private void buttonBetoltes_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("futottakmeg.txt");
                var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                var t = csv.GetRecords<Fut�k>();

                foreach (var item in t)
                {
                    fut�k.Add(item);
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonMentes_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
                    var t = csv.WriteRecords<Fut�k>;

                    sw.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fut�kBindingSource.Current == null) return;

            if (MessageBox.Show("A","B",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                fut�kBindingSource.RemoveCurrent();
            }
        }
    }
}
