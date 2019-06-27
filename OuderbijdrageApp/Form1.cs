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

            byte kinder_jonger_dan_tien_jaar = 0, kinderen_tien_jaar_of_ouder = 0;
            foreach (DateTime i in listBox1.Items)
            {
                if (peildatum.Subtract(i) >= tien_jaar_tijd)
                {
                    kinderen_tien_jaar_of_ouder++;
                } else
                {
                    kinder_jonger_dan_tien_jaar++;
                }
            }
            kinder_jonger_dan_tien_jaar = Math.Min(kinder_jonger_dan_tien_jaar, (byte)3 );//max bijdrage voor 3 kinderen. rest word kwijtgescholden
            kinderen_tien_jaar_of_ouder = Math.Min(kinderen_tien_jaar_of_ouder, (byte)2 );//max bijdrage voor 2 kinderen (> 10 jaar). rest word kwijtgescholden.

            float Ouderbijdrage = 50 + 25 * kinder_jonger_dan_tien_jaar + 37 * kinderen_tien_jaar_of_ouder;

            //limiet van 150 euro per ouderbijdrage
            Ouderbijdrage = Math.Min(Ouderbijdrage, 150);

            if (checkBox1.Checked)//== éénouder-gezin
            {
                Ouderbijdrage *=  (3/4f);
            }

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

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOuderbijdrage();
        }
    }
}
