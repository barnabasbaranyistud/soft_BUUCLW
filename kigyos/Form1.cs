namespace kigyos
{
    public partial class Form1 : Form
    {
        int fejX = 100;
        int fejY = 100;
        int irány_x = 1;
        int irány_y = 0;
        int lépésszám;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lépésszám++;
            fejX += irány_x * KígyóElem.Méret;
            fejY += irány_y * KígyóElem.Méret;
            KígyóElem ke = new();
            ke.Top = fejY;
            ke.Left = fejX;
            Controls.Add(ke);
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