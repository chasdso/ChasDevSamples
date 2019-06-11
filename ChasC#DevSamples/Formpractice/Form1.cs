using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoxofWidgees;


namespace Formpractice
{
    
    public partial class Form1 : Form
    {
        public int TimesTwo(int x) => x * 2;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Insert Text";
            textBox1.Text = "enter text here";
            label2.Text = "Insert Int";
            textBox2.Text = "0";
            label3.Text = "No input";
            button1.Text = "DoMe";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string myText = textBox1.Text;
            ////int myNumeric = Convert.ToInt32(textBox2.Text);
            Widgee getDate = new Widgee();
            label3.Text = getDate.Created.ToString();

        }
        
    }
            
   }




   