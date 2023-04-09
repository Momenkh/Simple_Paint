using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Practical
{
    public partial class Form2 : Form
    {
        Color clr;
        float thick;
        public Form2()
        {
            InitializeComponent();
        }
        public Color Clr
        {
            set { clr = value; }
            get { return clr; }
        }
        public new float Thick
        {

            set
            {
                thick = value;
            }

            get
            {
                if (radioButton1.Checked == true)
                {
                    thick = 1;
                }
                else if (radioButton2.Checked == true)
                {
                    thick = 2;
                }
                else if (radioButton3.Checked == true)
                {
                    thick = 3;
                }
                else if (radioButton4.Checked == true)
                {
                    thick = 4;
                }
                else if (radioButton5.Checked == true)
                {
                    thick = 5;
                }
                return thick;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog X = new ColorDialog();
            DialogResult Y = X.ShowDialog();
            if (Y == DialogResult.OK)
            {
                Clr = X.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
