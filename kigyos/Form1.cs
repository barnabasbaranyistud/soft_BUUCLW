namespace kigyos
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        int fejX = 100;
        int fejY = 100;
        int irány_x = 1;
        int irány_y = 0;
        int lépésszám;
        int hossz = 5;
        int almaszám;

        int almaX;
        int almaY;

        Alma a = new();

        List<KígyóElem> kígyó = new();
        List<Alma> alma = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        lépésszám++;
            fejX += irány_x * KígyóElem.Méret;
            fejY += irány_y * KígyóElem.Méret;

            foreach (PictureBox item in Controls)
            {
                if (item is KígyóElem)
                {
                    KígyóElem k = (KígyóElem)item;
                    if (k.Top == fejY && k.Left == fejX)
                    {
                        timer1.Enabled = false;
                        return;
                    }
                }
            }

            KígyóElem ke = new();
            ke.Top = fejY;
            ke.Left = fejX;
            kígyó.Add(ke);
            Controls.Add(ke);

            if (lépésszám % 2 == 0) { ke.BackColor = Color.Yellow; }

            if (kígyó.Count > hossz)
            {
                KígyóElem levágandó = kígyó[0];
                kígyó.RemoveAt(0);
                Controls.Remove(levágandó);
            }
           

            if (almaY == fejY && almaX == fejX)
            {
                hossz += 1;
                Controls.Remove(a);
                almaszám = 0;
            }

            if (almaszám == 0)
            {
                almaY = (int)rnd.Next(ClientRectangle.Height / 20) * 20;
                almaX = (int)rnd.Next(ClientRectangle.Width / 20) * 20;
                foreach (PictureBox item in Controls)
                {
                    if (item is KígyóElem)
                    {
                        KígyóElem k = (KígyóElem)item;
                        if (k.Top == almaY && k.Left == almaX)
                        {
                            almaY = (int)rnd.Next(ClientRectangle.Height / 20) * 20;
                            almaX = (int)rnd.Next(ClientRectangle.Width / 20) * 20;
                            return;
                        }
                    }
                }
            }
                a.Top = almaY;
                a.Left = almaX;
                Controls.Add(a);
                almaszám = 1;
            }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                irány_y = -1;
                irány_x = 0;
            }

            if (e.KeyCode == Keys.Down)
            {
                irány_y = 1;
                irány_x = 0;
            }

            if (e.KeyCode == Keys.Left)
            {
                irány_y = 0;
                irány_x = -1;
            }

            if (e.KeyCode == Keys.Right)
            {
                irány_y = 0;
                irány_x = 1;
            }
        }
    }
}