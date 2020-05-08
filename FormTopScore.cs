using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace CourseWork
{
    public partial class FormTopScore : Form
    {
        public List<UsersInTopScore> tableTopSccore = new List<UsersInTopScore>();
        int numberOfTop = 10;

        public FormTopScore(Difficulty diff)
        {
            InitializeComponent();
            buttonBack.Click += buttonBack_Click;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.Items.AddRange(new object[] 
            {
                Difficulty.Easy, Difficulty.Normal, Difficulty.Hard
            });
            comboBox1.SelectedItem = diff; 
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                dataGridTableOfTopScore.DataSource = LoadTable(comboBox1.SelectedItem);
            }
        }

        public void tableTopSccoreAdd(UsersInTopScore user)
        {
            tableTopSccore.Add(user);
            tableTopSccore.Sort();
            if (tableTopSccore.Count() > numberOfTop)
            {
                tableTopSccore.RemoveAt(numberOfTop);
            }
        }

        public List<UsersInTopScore> LoadTable(object diff)
        {
            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<UsersInTopScore>));
                using (TextReader reader = new StreamReader("TopScoreTable" + diff + ".xml"))
                {
                    return tableTopSccore = (List<UsersInTopScore>)deSerializer.Deserialize(reader);
                }                
            }
            catch (IOException) 
            {
                return new List<UsersInTopScore>();
            }
        }

        void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public int NumberOfTop
        {
            get
            {
                return numberOfTop;
            }
        }

    }
}
