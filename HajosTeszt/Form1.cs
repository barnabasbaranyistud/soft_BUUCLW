namespace HajosTeszt
{
    public partial class Form1 : Form
    {
        List<Kérdés> ÖsszesKérdés;
        List<Kérdés> AktívKérdések;
        int actual = 1;
        public Form1()
        {
            InitializeComponent();
        }
        List<Kérdés> KérdésBeolvasás()
        {
            List<Kérdés> kérdések = new List<Kérdés>();
            StreamReader sr = new StreamReader("text.txt", true);

            while (!sr.EndOfStream)
            {

                string sor = sr.ReadLine() ?? string.Empty;

                string[] tömb = sor.Split("\t");
                if (tömb.Length != 7) continue;

                Kérdés k = new Kérdés();
                k.KérdésSzöveg = tömb[1];
                k.Válasz1 = tömb[2];
                k.Válasz2 = tömb[3];
                k.Válasz3 = tömb[4];
                k.URL = tömb[5];

                int.TryParse(tömb[6], out int jóválasz);

                k.HelyesVálasz = jóválasz;

                kérdések.Add(k);
            }
            sr.Close();
            return kérdések;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AktívKérdések = new List<Kérdés>();
            ÖsszesKérdés = KérdésBeolvasás();

            for (int i = 0; i < 7; i++)
            {
                AktívKérdések.Add(ÖsszesKérdés[0]);
                ÖsszesKérdés.RemoveAt(0);
            }

            dataGridView1.DataSource = AktívKérdések;
            KérdésMegjelenítés(AktívKérdések[actual]);
        }

        void KérdésMegjelenítés(Kérdés kérdés)
        {
            label1.Text = kérdés.KérdésSzöveg;
            válaszGomb1.Text = kérdés.Válasz1;
            válaszGomb2.Text = kérdés.Válasz2;
            válaszGomb3.Text = kérdés.Válasz3;
            if (!string.IsNullOrEmpty(kérdés.URL))
            {
                pictureBox1.Load("https://storage.altinum.hu/hajo/" + kérdés.URL);
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KérdésMegjelenítés(AktívKérdések[actual]);
            actual++;
            if (actual == 7) actual = 0;
        }

    }
}