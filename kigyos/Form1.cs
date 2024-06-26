namespace kigyos
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        int fejX = 100;
        int fejY = 100;
        int ir�ny_x = 1;
        int ir�ny_y = 0;
        int l�p�ssz�m;
        int hossz = 5;
        int almasz�m;

        int almaX;
        int almaY;

        Alma a = new();

        List<K�gy�Elem> k�gy� = new();
        List<Alma> alma = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        l�p�ssz�m++;
            fejX += ir�ny_x * K�gy�Elem.M�ret;
            fejY += ir�ny_y * K�gy�Elem.M�ret;

            foreach (PictureBox item in Controls)
            {
                if (item is K�gy�Elem)
                {
                    K�gy�Elem k = (K�gy�Elem)item;
                    if (k.Top == fejY && k.Left == fejX)
                    {
                        timer1.Enabled = false;
                        return;
                    }
                }
            }

            K�gy�Elem ke = new();
            ke.Top = fejY;
            ke.Left = fejX;
            k�gy�.Add(ke);
            Controls.Add(ke);

            if (l�p�ssz�m % 2 == 0) { ke.BackColor = Color.Yellow; }

            if (k�gy�.Count > hossz)
            {
                K�gy�Elem lev�gand� = k�gy�[0];
                k�gy�.RemoveAt(0);
                Controls.Remove(lev�gand�);
            }
           

            if (almaY == fejY && almaX == fejX)
            {
                hossz += 1;
                Controls.Remove(a);
                almasz�m = 0;
            }

            if (almasz�m == 0)
            {
                almaY = (int)rnd.Next(ClientRectangle.Height / 20) * 20;
                almaX = (int)rnd.Next(ClientRectangle.Width / 20) * 20;
                foreach (PictureBox item in Controls)
                {
                    if (item is K�gy�Elem)
                    {
                        K�gy�Elem k = (K�gy�Elem)item;
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
                almasz�m = 1;
            }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ir�ny_y = -1;
                ir�ny_x = 0;
            }

            if (e.KeyCode == Keys.Down)
            {
                ir�ny_y = 1;
                ir�ny_x = 0;
            }

            if (e.KeyCode == Keys.Left)
            {
                ir�ny_y = 0;
                ir�ny_x = -1;
            }

            if (e.KeyCode == Keys.Right)
            {
                ir�ny_y = 0;
                ir�ny_x = 1;
            }
        }
    }
}