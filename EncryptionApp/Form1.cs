using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadTextfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFileDialog1.FileName;
                textBox1.Text = new System.IO.StreamReader(openFileDialog1.FileName).ReadToEnd();
            }
        }

        private void LoadEncryptedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = new System.IO.StreamReader(openFileDialog1.FileName).ReadToEnd(); 
                textBox2.Text = new System.IO.StreamReader(openFileDialog1.FileName).ReadToEnd();
            }
        }

        private void SaveEncryptedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = saveFileDialog1.FileName;
                StreamWriter savefile = new System.IO.StreamWriter(saveFileDialog1.FileName);
                savefile.Write(textBox2.Text);
                savefile.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EncryptText();
        }


        /*
         * encrypt; [0..255] => [33..65][33..65]
         *          [0..2^8] => [2^4+1..2^5+1][2^4+1..2^5+1]
         */


        private void EncryptText()
        {
            //Base64: pseudo-encryption! No real encryption
            byte[] bytelist = Encoding.ASCII.GetBytes(textBox1.Text);
            textBox2.Text = Convert.ToBase64String(bytelist);
        }
        private void DecryptText()
        {
            //Base64: pseudo-encryption! No real encryption
            byte[] bytelist = Convert.FromBase64String(textBox2.Text);
            textBox1.Text = Encoding.ASCII.GetString(bytelist);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DecryptText();
        }
    }
}
