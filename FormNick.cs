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
    public partial class FormNick : Form
    {

        string nick;

        public FormNick()
        {
            InitializeComponent();
            buttonSave.Click += buttonSave_Click;
        }


        public string Nick
        {
            get 
            {
                return nick;
            }
        }

        void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
                nick = textBox.Text;
                this.DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("Enter your nick");
        }


    }
}
