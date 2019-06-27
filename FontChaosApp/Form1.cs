using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontChaosApp
{
    public partial class Form1 : Form
    {
        Random random_seed;
        List<Font> fonts = new List<Font>();

        public Form1()
        {
            InitializeComponent();
            InitFonts();
            random_seed = new Random();
        }

        private void InitFonts()
        {
            FontFamily[] fontfamilies = FontFamily.Families;
            for(int i = 0; i < fontfamilies.Length; i++)
            {
                fonts.Add( new Font(fontfamilies[i].Name, 14) );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            fonts.Sort((x, y) => random_seed.Next(-1, 1));
            //fonts.ToList<Font>(x => random_seed.Next());
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                Char selected_char = richTextBox1.SelectedText[0];
                richTextBox1.SelectionFont = fonts[(int)selected_char % fonts.Count];

            }

        }
    }
}
