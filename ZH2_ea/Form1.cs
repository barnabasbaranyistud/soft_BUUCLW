using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace ZH2_ea
{
    public partial class Form1 : Form
    {
        BindingList<Futók> futók = new();
        public Form1()
        {
            InitializeComponent();
            ///dataGridView1.DataSource = futók; ///!!!!!!!!!!!!!!!!!BINDING SOURCE UTÁN TÖRÖLNI, ADDIG JÓ
            futókBindingSource.DataSource = futók;

        }

        private void buttonBetoltes_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("futottakmeg.txt");
                var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                var t = csv.GetRecords<Futók>();

                foreach (var item in t)
                {
                    futók.Add(item);
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
                    var t = csv.WriteRecords<Futók>;

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
            if (futókBindingSource.Current == null) return;

            if (MessageBox.Show("A", "B", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                futókBindingSource.RemoveCurrent();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUjFuto fuf = new FormUjFuto();

            if (fuf.ShowDialog() == DialogResult.OK)
            {
                futókBindingSource.Add(fuf.Újfutó);
            }
        }
    }
}
