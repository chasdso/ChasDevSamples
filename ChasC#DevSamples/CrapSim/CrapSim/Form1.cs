using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrapSim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rounds.Text = "10000";
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            int total7s = 0;
            int rounds = Convert.ToInt32(Rounds.Text);
            int doub7 = 0;
            int lastroll = 0;
            int roll = 0;
            //double perc7 = 0;
            //double percdoub7 = 0;
            RollDice rollem = new RollDice();

            for (int i = 1; i <= rounds; i++)
            {
                roll = rollem.DiceRoll();
                
                if (roll == 7)
                {
                    if (lastroll == 7)
                    {
                        doub7++;
                    }
                    total7s++;
                }
                lastroll = roll;
            }

            //perc7 = (double)total7s / rounds * 100;
            Perc7.Text = Convert.ToString(total7s);
            //percdoub7 = (double)doub7/total7s*100;
            Double7.Text = Convert.ToString(doub7);


        }

        private void Rounds_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
