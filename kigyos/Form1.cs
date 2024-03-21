namespace kigyos
{
    public partial class Form1 : Form
    {
        int fejX = 100;
        int fejY = 100;
        int ir�ny_x = 1;
        int ir�ny_y = 0;
        int l�p�ssz�m;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            l�p�ssz�m++;
            fejX += ir�ny_x * K�gy�Elem.M�ret;
            fejY += ir�ny_y * K�gy�Elem.M�ret;
            K�gy�Elem ke = new();
            ke.Top = fejY;
            ke.Left = fejX;
            Controls.Add(ke);
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