namespace HajosTeszt
{
    public partial class Form1 : Form
    {
        List<K�rd�s> �sszesK�rd�s;
        List<K�rd�s> Akt�vK�rd�sek;
        int actual = 1;
        public Form1()
        {
            InitializeComponent();
        }
        List<K�rd�s> K�rd�sBeolvas�s()
        {
            List<K�rd�s> k�rd�sek = new List<K�rd�s>();
            StreamReader sr = new StreamReader("text.txt", true);

            while (!sr.EndOfStream)
            {

                string sor = sr.ReadLine() ?? string.Empty;

                string[] t�mb = sor.Split("\t");
                if (t�mb.Length != 7) continue;

                K�rd�s k = new K�rd�s();
                k.K�rd�sSz�veg = t�mb[1];
                k.V�lasz1 = t�mb[2];
                k.V�lasz2 = t�mb[3];
                k.V�lasz3 = t�mb[4];
                k.URL = t�mb[5];

                int.TryParse(t�mb[6], out int j�v�lasz);

                k.HelyesV�lasz = j�v�lasz;

                k�rd�sek.Add(k);
            }
            sr.Close();
            return k�rd�sek;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Akt�vK�rd�sek = new List<K�rd�s>();
            �sszesK�rd�s = K�rd�sBeolvas�s();

            for (int i = 0; i < 7; i++)
            {
                Akt�vK�rd�sek.Add(�sszesK�rd�s[0]);
                �sszesK�rd�s.RemoveAt(0);
            }

            dataGridView1.DataSource = Akt�vK�rd�sek;
            K�rd�sMegjelen�t�s(Akt�vK�rd�sek[actual]);
        }

        void K�rd�sMegjelen�t�s(K�rd�s k�rd�s)
        {
            label1.Text = k�rd�s.K�rd�sSz�veg;
            v�laszGomb1.Text = k�rd�s.V�lasz1;
            v�laszGomb2.Text = k�rd�s.V�lasz2;
            v�laszGomb3.Text = k�rd�s.V�lasz3;
            if (!string.IsNullOrEmpty(k�rd�s.URL))
            {
                pictureBox1.Load("https://storage.altinum.hu/hajo/" + k�rd�s.URL);
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            K�rd�sMegjelen�t�s(Akt�vK�rd�sek[actual]);
            actual++;
            if (actual == 7) actual = 0;
        }
    }
}