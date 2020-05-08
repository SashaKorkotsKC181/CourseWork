using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class FormStartMenu : Form
    {

        FormGameSetUp gameSetUp;

        public FormStartMenu(FormGameSetUp gameSetUp_)
        {
            InitializeComponent();
            gameSetUp = gameSetUp_;
            buttonStart.Click += buttonStart_Click;
            buttonExit.Click += buttonExit_Click;
            buttonTopScore.Click += buttonTopScore_Click;
        }

        void buttonTopScore_Click(object sender, EventArgs e)
        {
            new FormTopScore(Difficulty.Hard).ShowDialog();
        }

        void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void buttonStart_Click(object sender, EventArgs e)
        {
            if (gameSetUp.ShowDialog() == DialogResult.OK)
                this.DialogResult = DialogResult.OK;
        }
    } 
}
