using System;
using System.Collections;
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
        Hashtable hashtable = new Hashtable();
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
        public int[] par = new int[4];
        public int[] rap = new int[6];
        public int[] cab = new int[17];

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
                    try
                    {
                        par[0] = Convert.ToInt32(hashtable[value[1]]);
                        par[1] = Convert.ToInt32(hashtable[value[2]]);
                       
                    }
                    catch 
                    {
                        par[0] = Convert.ToInt32(value[1]);
                        par[1] = Convert.ToInt32(value[2]);
                       
                    }
                    try
                    {
                        rap[0] = Convert.ToInt32(hashtable[value[1]]);
                        rap[1] = Convert.ToInt32(hashtable[value[2]]);
                    }
                    catch
                    {
                        rap[0] = Convert.ToInt32(value[1]);
                        rap[1] = Convert.ToInt32(value[2]);
                    }

                    try
                    {
                        cab[0] = Convert.ToInt32(hashtable[value[1]]);
                        cab[1] = Convert.ToInt32(hashtable[value[2]]);
                    }
                    catch
                    {
                        cab[0] = Convert.ToInt32(value[1]);
                        cab[1] = Convert.ToInt32(value[2]);
                    }
                }
                else if (value[0].Equals("int"))
                {
                    if (value[2].Equals("=")&&value[4].Equals(";"))
                    {
                        int start = line[i].IndexOf("var") + "var".Length;
                        int final = line[i].LastIndexOf("=");

                        String store = line[i].Substring(start, final - start).Replace(" ", String.Empty);

                        int begin = line[i].IndexOf("=") + "=".Length;
                        int end = line[i].LastIndexOf(";");

                        int store1 = Int32.Parse(line[i].Substring(begin, end - begin).Replace(" ", String.Empty));
                        try
                        {
                            hashtable.Add(store, store1);
                        }
                        catch (Exception x)
                        {
                            hashtable[store] = store1;
                        }


                    }
                    MessageBox.Show("" + hashtable);

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
                    if (value[0].Equals("Triangle", StringComparison.OrdinalIgnoreCase))
                    {
                        abstractShapes bac = factory.getShape("Triangle");

                        rap[2] = Convert.ToInt32(value[1]);
                        rap[3] = Convert.ToInt32(value[2]);
                        rap[4] = Convert.ToInt32(value[3]);
                        rap[5] = Convert.ToInt32(value[4]);
                        bac.setData(rap);
                        bac.drawShape(e.Graphics);
                    }
                    if (value[0].Equals("POLYGON", StringComparison.OrdinalIgnoreCase))
                    {
                        abstractShapes abs = factory.getShape("POLYGON");

                        cab[2] = Convert.ToInt32(value[1]);
                        cab[3] = Convert.ToInt32(value[2]);
                        cab[4] = Convert.ToInt32(value[3]);
                        cab[5] = Convert.ToInt32(value[4]);
                        cab[6] = Convert.ToInt32(value[5]);
                        cab[7] = Convert.ToInt32(value[6]);
                        cab[8] = Convert.ToInt32(value[7]);
                        cab[9] = Convert.ToInt32(value[8]);

                        abs.setData(cab);
                        abs.drawShape(e.Graphics);

                    }


                
            }
        }
    
}

