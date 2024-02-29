namespace Gyakorlo4
{
    public partial class Form1 : Form
    {
        Random rng = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                Button uj = new Button();
                uj.Width = rng.Next(20, 61);
                uj.Height = rng.Next(20, 61);

                uj.Top = rng.Next(ClientSize.Height - uj.Height);
                uj.Left = rng.Next(ClientSize.Width - uj.Width);
                
                int r = rng.Next(255);
                int b = rng.Next(255);
                int g = rng.Next(255);

                uj.BackColor = Color.FromArgb(r, b, g);

                Controls.Add(uj);



            }
        }
    }
}