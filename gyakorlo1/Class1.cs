using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakorlo1
{
    public class  VillogoGomb : Button
    {
        public VillogoGomb() 
        {
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;
        }

        private void OnMouseEnter(object? sender, EventArgs e)
        {
            BackColor = Color.Fuchsia;
        }

        private void OnMouseLeave(object? sender, EventArgs e)
        {
            BackColor = SystemColors.ButtonFace;
        }
    }
}
