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
                EncrypedText = Encoding.ASCII.GetBytes(
                                    new System.IO.StreamReader(openFileDialog1.FileName).ReadToEnd()
                                );
                textBox2.Text = Encoding.ASCII.GetString(EncrypedText).Replace("\0", "\\0");
            }
        }

        private void SaveEncryptedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = saveFileDialog1.FileName;
                StreamWriter savefile = new System.IO.StreamWriter(saveFileDialog1.FileName);
                savefile.Write(Encoding.ASCII.GetString(EncrypedText) );
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



        byte[] EncryptionKeychain = new byte[3] { 149, 211, 35 };
        byte[] RuntimeKeychain;
        byte[] EncrypedText;
        private void EncryptText()
        {

            byte[] bytelist = Encoding.ASCII.GetBytes(textBox1.Text);
            for (int i = 0; i <bytelist.Length; i++)
            {
                byte curchar = bytelist[i];
                foreach (byte ec in EncryptionKeychain)
                {
                    curchar = (byte)(curchar ^ ec);
                }
                bytelist[i] = curchar;
            }
            EncrypedText = bytelist;
            textBox2.Text = Encoding.ASCII.GetString(EncrypedText).Replace("\0", "\\0");

        }
        private void DecryptText()
        {
            byte[] bytelist = EncrypedText;
            
            for (int i = 0; i < EncrypedText.Length; i++)
            {
                byte curchar = EncrypedText[i];

                foreach (byte ec in EncryptionKeychain)
                {
                    curchar = (byte)(curchar ^ ec);
                }
                bytelist[i] = curchar;
            }

            textBox1.Text = Encoding.ASCII.GetString(bytelist);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DecryptText();
        }
    }
}
