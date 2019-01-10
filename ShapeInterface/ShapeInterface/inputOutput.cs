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
    public partial class inputOutput : Form
    {
        String[] value;
        String[] line;
        Form1 f1;
        drawFactory factory = new drawFactory();
        public inputOutput(Form1 f1)
        {
            InitializeComponent();

            this.f1 = f1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            run.TabStop = false;
            run.FlatStyle = FlatStyle.Flat;
            run.FlatAppearance.BorderSize = 0;
            run.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            panel1.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            exit.TabStop = false;
            exit.FlatStyle = FlatStyle.Flat;
            exit.FlatAppearance.BorderSize = 0;
            exit.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            Application.Exit();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;//instantiating null value for stra
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//creating a instance of a dialog box
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //creting text form
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)//if choose data is fine then enter todialog box
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null) //if the choosen file is not empty then the file is read
                    {
                        using (myStream) //dispose is done automatically
                        {
                            edit.Text = File.ReadAllText(openFileDialog1.FileName);//loading text file in textbox
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();//creating a instance of a dialog box
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //creting text form
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)//if choose data is fine then enter todialog box
            {
                try
                {

                    using (StreamWriter write = new StreamWriter(sfd.FileName)) //dispose is done automatically
                    {
                        await write.WriteLineAsync(edit.Text);//loading text file in textbox
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void help_Click(object sender, EventArgs e)
        {

            var fileStream = new FileStream(@"E:\study\ShapeandDraw\help.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                edit.Text = streamReader.ReadToEnd();
            }
        }

        private void edit_TextChanged(object sender, EventArgs e)
        {
            
        }
       public int [] par= new int[4];
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            //spliting string with different escape sequence;



            for (int i = 0; i < edit.Lines.Length - 1; i++)//counting length of program
            {
                //stored counted length in string
                line = edit.Lines;
                value = line[i].Split(' ');
               

                if (value[0].Equals("DrawTo", StringComparison.OrdinalIgnoreCase))  //parsing the command
                {
                    
                    par[0] = Convert.ToInt32(value[1]);
                    par[1] = Convert.ToInt32(value[2]);
                   
                }

                if (value[0].Equals("Rectangle", StringComparison.OrdinalIgnoreCase))//checking the command
                {
                    abstractShapes ab = factory.getShape("Rectangle");
                    par[2] = Convert.ToInt32(value[1]);
                    par[3] = Convert.ToInt32(value[2]);

                    ab.setData(par);
                    ab.drawShape(e.Graphics);  
                }


               if (value[0].Equals("Circle", StringComparison.OrdinalIgnoreCase))
                {
                    abstractShapes ba = factory.getShape("Circle");
                    par[2] = Convert.ToInt32(value[1]);
                    par[3] = Convert.ToInt32(value[2]);
                    ba.setData(par);
                    ba.drawShape(e.Graphics);
                    
                }



            }
        }
    }
}

