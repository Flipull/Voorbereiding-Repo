using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OuderbijdrageApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.MaxDate = dateTimePicker1.Value;
        }

        //
        private void CalculateOuderbijdrage()
        {
            DateTime peildatum = dateTimePicker1.Value;
            TimeSpan tien_jaar_tijd = TimeSpan.FromDays(10 * 365);

            byte kinder_aantal = 0, kinderen_tien_jaar_of_ouder = 0;
            foreach (DateTime i in listBox1.Items)
            {
                kinder_aantal++;
                if (peildatum.Subtract(i) >= tien_jaar_tijd)
                {
                    kinderen_tien_jaar_of_ouder++;
                }
            }
            kinder_aantal = Math.Min(kinder_aantal, (byte)3 );//maximaal ouderbijdrage voor 3 kinderen totaal.
            kinderen_tien_jaar_of_ouder = Math.Min(kinderen_tien_jaar_of_ouder, (byte)2 );//maximaal ouderbijdrage voor 2 kinderen over de 10 jaar oud.

            float Ouderbijdrage = 50 + 25 * kinder_aantal + 12 * kinderen_tien_jaar_of_ouder;

            if (kinder_aantal == 1)
                Ouderbijdrage =  Ouderbijdrage * (3 / 4f);//25% korting

            label3.Text = "Totale Ouderbijdrage: € " + Ouderbijdrage;
        }
        //

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MaxDate = dateTimePicker1.Value;
            dateTimePicker2.Value = dateTimePicker1.Value;
            listBox1.Items.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(dateTimePicker2.Value);

            CalculateOuderbijdrage();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            CalculateOuderbijdrage();
        }
    }
}
