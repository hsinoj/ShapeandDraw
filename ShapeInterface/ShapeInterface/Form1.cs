using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeInterface
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

        }
        /// <summary>
        /// another form is called
        /// openeing specific form
        /// closing current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            inputOutput ed = new inputOutput(this); //creating instance of another form
            ed.Show(); //opening the specific form
            Visible = false; //closing the current form
        }
        /// <summary>
        /// openign a file explore dialog box
        /// data reads only in text format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button2_Click(object sender, EventArgs e)
        {
            inputOutput ed = new inputOutput(this);

            Stream myStream1 = null;//instantiating null value for stra
            OpenFileDialog openFileDialog2 = new OpenFileDialog();//creating a instance of a dialog box

            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //creting text form
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)//if choose data is fine then enter todialog box
            {
                try
                {
                    if ((myStream1 = openFileDialog2.OpenFile()) != null) //if the choosen file is not empty then the file is read
                    {
                        using (myStream1) //dispose is done automatically
                        {

                            ed.edit.Text = File.ReadAllText(openFileDialog2.FileName);//loading text file in textbox    
                        }
                        ed.Show(); //opening the specific form
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


