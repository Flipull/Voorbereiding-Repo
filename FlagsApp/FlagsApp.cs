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
    public partial class FlagsApp : Form
    {

        List<Flag> FlagList = new List<Flag>();
        Random randgen = new Random();

        private int Puzzlestotal = 0;
        private int PuzzlesCorrect = 0;


        public FlagsApp()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Show AllFlags-Form
            AllFlags modalform = new AllFlags();
            modalform.SetFlags(FlagList);
            modalform.ShowDialog();

        }

        private void FlagsApp_Load(object sender, EventArgs e)
        {
            //load flags from folder/files + filenames
            IEnumerable<String> files = System.IO.Directory.EnumerateFiles("png/");
            foreach (String file in files)
            {
                String friendlyname = System.IO.Path.GetFileName(file);
                friendlyname = friendlyname.Substring(4, friendlyname.Length-4-4);

                Flag currentflag = new Flag(friendlyname, Bitmap.FromFile(file));
                FlagList.Add(currentflag);
            }


            SetPuzzle();
        }

        int correctAnswer, chosenAnswer;
        private void SetPuzzle()
        {
            List<Flag> FlagsPuzzle = new List<Flag>();
            correctAnswer = randgen.Next(4);
            for (int i=0; i < 4; i++)
            {
                int choice = randgen.Next(FlagList.Count);
                FlagsPuzzle.Add(FlagList[choice]);

            }
            pictureBox1.Image = FlagsPuzzle[correctAnswer].FlagImage;

            radioButton1.Text = FlagsPuzzle[0].FlagName;
            radioButton2.Text = FlagsPuzzle[1].FlagName;
            radioButton3.Text = FlagsPuzzle[2].FlagName;
            radioButton4.Text = FlagsPuzzle[3].FlagName;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            chosenAnswer = -1;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = pictureBox3.Image;
            pictureBox3.Image = pictureBox2.Image;


            if (chosenAnswer == correctAnswer)
            {
                PuzzlesCorrect++;
                Puzzlestotal++;

                Bitmap drawnImage = new Bitmap(pictureBox1.Image);
                Graphics canvas = Graphics.FromImage(drawnImage);
                canvas.DrawRectangle(new Pen(new SolidBrush(Color.LimeGreen), 40),
                                        0, 0, drawnImage.Width, drawnImage.Height);

                pictureBox2.Image = drawnImage;
            }
            else
            {
                Puzzlestotal++;

                Bitmap drawnImage = new Bitmap(pictureBox1.Image);
                Graphics canvas = Graphics.FromImage(drawnImage);
                canvas.DrawRectangle(new Pen(new SolidBrush(Color.OrangeRed), 40),
                                        0, 0, drawnImage.Width, drawnImage.Height);

                pictureBox2.Image = drawnImage;
            }


            SetPuzzle();
            float score = PuzzlesCorrect / (float) Puzzlestotal * 100;
            label1.Text =  Math.Floor(score) + "% Correct";
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chosenAnswer = 0;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chosenAnswer = 1;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            chosenAnswer = 2;
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            chosenAnswer = 3;
        }
    }
}
