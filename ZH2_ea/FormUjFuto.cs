using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZH2_ea
{
    public partial class FormUjFuto : Form
    {
        public Futók Újfutó = new Futók();
        public FormUjFuto()
        {
            InitializeComponent();
            futókBindingSource.DataSource = Újfutó;
        }
    }
}
