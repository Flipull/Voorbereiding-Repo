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
        private Encryption EncryptObject = new Encryption();
        private static byte[] HARDCODED_PASSWORD = Encoding.ASCII.GetBytes("Hallo");
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
                EncryptedText = Encoding.ASCII.GetBytes(
                                    new System.IO.StreamReader(openFileDialog1.FileName).ReadToEnd()
                                );
                textBox2.Text = Encoding.ASCII.GetString(EncryptedText).Replace("\0", "\\0");
            }
        }

        private void SaveEncryptedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = saveFileDialog1.FileName;
                StreamWriter savefile = new System.IO.StreamWriter(saveFileDialog1.FileName);
                savefile.Write(Encoding.ASCII.GetString(EncryptedText) );
                savefile.Close();
            }
        }

        byte[] EncryptedText= new byte[0];//variable introduced because TextBox-UI elements can't display null-bytes
        private void Button1_Click(object sender, EventArgs e)
        {
            EncryptedText = EncryptObject.XorEncrypt(Encoding.ASCII.GetBytes(textBox1.Text), HARDCODED_PASSWORD);
            textBox2.Text = Encoding.ASCII.GetString(EncryptedText).Replace("\0", "\\0");
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
          
            byte[] decrypted_result = EncryptObject.XorDecrypt(EncryptedText,  HARDCODED_PASSWORD);
            textBox1.Text = Encoding.ASCII.GetString(decrypted_result);
        }
    }
}
