using Microsoft.Win32.SafeHandles;

namespace Pascal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int sor = 0; sor < 10; sor++)
            {
                for (int oszlop = 0; oszlop <= 10; oszlop++)
                {
                    Button b = new Button();
                    b.Top = sor * 60;
                    b.Left = ClientRectangle.Width / 2 - 60*oszlop + sor*30;
                    b.Height = 60;
                    b.Width = 60;
                    int p = Faktorialis(sor) / (Faktorialis(oszlop) * (Faktorialis(sor - oszlop)));
                    b.Text = p.ToString();
                    if (int.Parse(b.Text) >= 1) Controls.Add(b);
                }
            }
        }
        int Faktorialis(int n)
        {
            int eredm�ny = 1;
            for (int i = 1; i <= n; i++) eredm�ny *= i;

            return eredm�ny;
        }

        int Faktorialis2(int n)
        {
            if (n == 0) return 1;
            return n * Faktorialis2(n - 1);
        }
    }
}
