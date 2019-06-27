using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchijventariefInkomstenbelastingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = Decimal.MaxValue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //belastbaar inkomen
            float belastbaar_inkomen = (float) numericUpDown1.Value;

            //belastingvrije som
            float belastingvrije_som = 0;
            switch (numericUpDown2.Value)
            {
                case 1:
                    belastingvrije_som = 419;
                    break;
                case 2:
                    belastingvrije_som = 8799;
                    break;
                case 3:
                    belastingvrije_som = 17179;
                    break;
                case 4:
                case 5:
                    belastingvrije_som = 15503;
                    break;
                default: throw new Exception();//never happens
            }
            belastingvrije_som += (float) Math.Min(belastbaar_inkomen * 0.12, 6704);

            //belastbare som
            float belastbare_som = belastbaar_inkomen - belastingvrije_som;

            
            
            
            
            //verschuldigde belasting
            float verschuldigde_belasting = 0;

            //eerste schijf t/m €8000
            if (belastbare_som >= 0)
            {
                verschuldigde_belasting += Math.Min(belastbare_som, 8000) * 0.3575f;
            }
            //tweede schijf t/m €25000
            if (belastbare_som >= 8000)
            {
                verschuldigde_belasting += Math.Min(belastbare_som-8000, 25000-8000) * 0.3705f;
            }
            //derde schijf t/m 54000
            if (belastbare_som >= 25000)
            {
                verschuldigde_belasting += Math.Min(belastbare_som-25000, 54000-25000) * 0.5f;
            }
            //vierde schijf
            if (belastbare_som >= 54000)
            {
                verschuldigde_belasting += (belastbare_som-54000) * 0.6f;
            }

            textBox1.Text = "€ " + verschuldigde_belasting;
        }
    }
}
