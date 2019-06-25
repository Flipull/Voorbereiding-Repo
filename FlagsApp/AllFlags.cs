using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class AllFlags : Form
    {
        private List<Flag> FlagList;
        private int CurrentFlag;
        public AllFlags()
        {
            InitializeComponent();
        }


        public void SetFlags(List<Flag> flaglist)
        {
            FlagList = flaglist;
        }

        private void AllFlags_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FlagList[CurrentFlag].FlagImage;
            label1.Text = FlagList[CurrentFlag].FlagName;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CurrentFlag--;
            if (CurrentFlag < 0)
                CurrentFlag = FlagList.Count-1;
            pictureBox1.Image = FlagList[CurrentFlag].FlagImage;
            label1.Text = FlagList[CurrentFlag].FlagName;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CurrentFlag++;
            if (CurrentFlag >= FlagList.Count-1)
                CurrentFlag = 0;
            pictureBox1.Image = FlagList[CurrentFlag].FlagImage;
            label1.Text = FlagList[CurrentFlag].FlagName;
        }
    }
}
