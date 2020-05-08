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
    public partial class FormGameSetUp : Form
    {
        public Difficulty difficulty;

        public FormGameSetUp()
        {
            InitializeComponent();
            buttonEasy.Click += buttonEasy_Click;
            buttonNormal.Click += buttonNormal_Click;
            buttonHard.Click += buttonHard_Click;
            buttonBack.Click += buttonBack_Click;
        }

        void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        void buttonHard_Click(object sender, EventArgs e)
        {
            difficulty = Difficulty.Hard;
            this.DialogResult = DialogResult.OK;
        }

        void buttonNormal_Click(object sender, EventArgs e)
        {
            difficulty = Difficulty.Normal;
            this.DialogResult = DialogResult.OK;
        }

        void buttonEasy_Click(object sender, EventArgs e)
        {
            difficulty = Difficulty.Easy;
            this.DialogResult = DialogResult.OK;
        }


    }
}
