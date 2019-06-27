using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpleidingsInstituutApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CalculateCursusKosten()
        {
            DateTime peil_minus_19jaar =
                new DateTime(dateTimePicker1.Value.Year - 19,
                                dateTimePicker1.Value.Month,
                                dateTimePicker1.Value.Day);
            bool jonger_dan_19_jaar = dateTimePicker2.Value > peil_minus_19jaar;
            
            bool bemiddeld = checkBox1.Checked;

            int[] vakken = new int[3];
            vakken[0] = (int)numericUpDown1.Value;
            vakken[1] = (int)numericUpDown2.Value;
            vakken[2] = (int)numericUpDown3.Value;
            int vakken_totaal = vakken.Sum();

            ////
            float les_kosten = 50 * vakken[0] + 150 * vakken[1] + 150 * vakken[2];

            float materiaal_kosten = 0;
            if (!bemiddeld)
                materiaal_kosten = 50 * vakken[0] + 50 * vakken[1] + 125 * vakken[2];

            
            //NB: combinatie van les-korting 5% en 2%, levert
            //maar 1-(0.95*0.98) = 6,9% korting op
            if (vakken_totaal >= 5)
                les_kosten *= 0.95f;

            if (jonger_dan_19_jaar)
            {
                les_kosten *= 0.98f;
                materiaal_kosten *= 0.98f;
            }


            label7.Text = "les € " + les_kosten;//test_info
            label8.Text = "materiaal € " + materiaal_kosten;//test_info
            
            label6.Text = "Verschuldigd bedrag: € " + (les_kosten + materiaal_kosten);


        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CalculateCursusKosten();
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculateCursusKosten();
        }

        private void OnVakValueChanged(object sender, EventArgs e)
        {
            CalculateCursusKosten();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCursusKosten();
        }
    }
}
