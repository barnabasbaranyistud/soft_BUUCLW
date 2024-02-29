using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakorlo1
{
    public class SzamoloGomb : Button
    {
        int szam = 1;
        public SzamoloGomb()
        {
            Width = 20;
            Height = 20;

            Click += SzamoloGomb_Click;

        }

        private void SzamoloGomb_Click(object? sender, EventArgs e)
        {
            if (szam < 5)szam += 1;
            else szam = 1;
            Text = szam.ToString();
        }
    }
}
