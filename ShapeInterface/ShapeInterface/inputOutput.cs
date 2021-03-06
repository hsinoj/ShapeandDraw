﻿using System;
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
    /// <summary>
    /// 
    /// </summary>
    public partial class inputOutput : Form
    {
        String[] value; //intiliazing array in ss=tring
        String[] line;
        Form1 f1;
        int counter;
         string store = null;
         int[] par2 = new int[2];
         int[] par3 = new int[4];
         int height = 0;
         int width = 0;
         int radius1 = 0;
         int h = 0;
         int p = 0;

        drawFactory factory = new drawFactory(); //creating draw factory instacne
        Hashtable hashtable = new Hashtable(); //creating hastable for mapping key and values
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f1"></param>
        public inputOutput(Form1 f1)
        {
            InitializeComponent();

            this.f1 = f1;
        }

        /// <summary>
        /// This part is for the user customization of button
        /// panel has been called
        /// </summary>
        /// <param name="sender">object is send</param>
        /// <param name="e">event is handele</param>
        private void button1_Click(object sender, EventArgs e)
        {
            run.TabStop = false;
            run.FlatStyle = FlatStyle.Flat;
            run.FlatAppearance.BorderSize = 0;
            run.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            panel1.Refresh(); //calling panel method
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            exit.TabStop = false;
            exit.FlatStyle = FlatStyle.Flat;
            exit.FlatAppearance.BorderSize = 0;
            exit.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            Application.Exit();
        }
        /// <summary>
        /// it is for opening the dialgbox
        /// open file into c drive. 
        /// Only text file is read
        /// the file is ready stream reader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// this part is for saving the textfield file
        /// stream write is used to wirte file in text fom
        /// asnc is use for loading file in text format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// reading file from file explorer
        /// the file is openend with the help of filestream
        /// stream reader is used for reading text file in text format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void help_Click(object sender, EventArgs e)
        {

            var fileStream = new FileStream(@"E:\study\ShapeandDraw\help.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                edit.Text = streamReader.ReadToEnd(); //text loaded in textbox
            }
        }

        private void edit_TextChanged(object sender, EventArgs e)
        {

        }
        //intiliazing array with diffeent index property
        /// <summary>
        /// instantiating array par
        /// </summary>
        public int[] par = new int[4];
        /// <summary>
        /// rap
        /// </summary>
        public int[] rap = new int[6];
        /// <summary>
        /// cab
        /// </summary>
        public int[] cab = new int[17];
       // public int[] arp = new int[4];


        /// <summary>
        /// this part is for reading textbox file line by line
        /// spliting the line by escape sequeence like by space
        /// creating own command for drawing 
        /// different basic geometry shapes and complex polygon and texture are drawn
        /// syntax checking 
        /// valid command and parameter is checked
        /// complex commandis done like repeat,loop and if end if confiton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            //spliting string with different escape sequence;
   


            for (int i = 0; i < edit.Lines.Length - 1; i++)//counting length of program
            {
                //stored counted length in string
                line = edit.Lines;
                value = line[i].Split(' ');

                //chekcing command
                if (value[0].Equals("DrawTo", StringComparison.OrdinalIgnoreCase)        || value[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase)
                      || value[0].Equals("Triangle", StringComparison.OrdinalIgnoreCase) || value[0].Equals("Rectangle", StringComparison.OrdinalIgnoreCase)
                      || value[0].Equals("Circle", StringComparison.OrdinalIgnoreCase)   || value[0].Equals("Polygon", StringComparison.OrdinalIgnoreCase)
                      || value[0].Equals("Loop", StringComparison.OrdinalIgnoreCase)     || value[0].Equals("Line", StringComparison.OrdinalIgnoreCase)
                      || value[0].Equals("IF")                                           || value[0].Equals("Texture", StringComparison.OrdinalIgnoreCase)
                      || value[0].Equals("width", StringComparison.OrdinalIgnoreCase)    || value[0].Equals("height", StringComparison.OrdinalIgnoreCase) 
                      || value[0].Equals("endloop", StringComparison.OrdinalIgnoreCase)  || value[0].Equals("circl", StringComparison.OrdinalIgnoreCase)
                      || value[0].Equals("radius", StringComparison.OrdinalIgnoreCase)   || value[0].Equals("triangl", StringComparison.OrdinalIgnoreCase)
                      || value[0].Equals("p", StringComparison.OrdinalIgnoreCase)        || value[0].Equals("h", StringComparison.OrdinalIgnoreCase)
                      || value[0].Equals("if")                                           || value[0].Equals("endIf", StringComparison.OrdinalIgnoreCase)
                      || value[0].Equals("var")                                          || value[0].Equals("Rectagnl", StringComparison.OrdinalIgnoreCase))
            {


                    if (value[0].Equals("DrawTo", StringComparison.OrdinalIgnoreCase))  //parsing the command
                    {
                        
                        

                        //rectangle
                        /*
                         * hcreating rectangle
                         * hashtable used for string so integer cannot loaded
                         * parsing the string variable to integer
                         * storing every variable in array
                         * try and catch is used
                         */
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
                            par[0] = Convert.ToInt32(hashtable[value[1]]);
                            par[1] = Convert.ToInt32(hashtable[value[2]]);

                        }
                        catch
                        {
                            par[0] = Convert.ToInt32(value[1]);
                            par[1] = Convert.ToInt32(value[2]);
                        }

                        //circle

                        try
                        {
                            par[0] = Convert.ToInt32(value[1]);
                            par[1] = Convert.ToInt32(value[2]);
                        }
                        catch
                        {
                            par[0] = Convert.ToInt32(hashtable[value[1]]);
                            par[1] = Convert.ToInt32(hashtable[value[2]]);
                        }
                        //triangle

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
                            rap[0] = Convert.ToInt32(value[1]);
                            rap[1] = Convert.ToInt32(value[2]);

                        }
                        catch
                        {
                            rap[0] = Convert.ToInt32(hashtable[value[1]]);
                            rap[1] = Convert.ToInt32(hashtable[value[2]]);
                        }

                        //polygon 
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

                        try
                        {
                            cab[0] = Convert.ToInt32(value[1]);
                            cab[1] = Convert.ToInt32(value[2]);
                        }
                        catch
                        {

                            cab[0] = Convert.ToInt32(hashtable[value[1]]);
                            cab[1] = Convert.ToInt32(hashtable[value[2]]);
                        }
                    }

                    //variable format
                    else if (value[0].Equals("var")) //checking whether first line var or not
                    {
                        if (value[2].Equals("=") == true && value[4].Equals(";") == true) //checking whether the line contain = or semi colo
                        {
                            int From = line[i].IndexOf("var") + "var".Length; //chcking the var positon
                            int To = line[i].LastIndexOf("="); //checking = sign position

                            String res = line[i].Substring(From, To - From).Replace(" ", String.Empty); //extract the long string 

                            int From1 = line[i].IndexOf("=") + "=".Length;
                            int To1 = line[i].LastIndexOf(";");

                            int res1 = Int32.Parse(line[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            try
                            {
                                hashtable.Add(res, res1);//key and values are passed
                            }
                            catch (Exception x)
                            {
                                hashtable[res] = res1;
                            }


                        }


                    }






                    if (value[0].Equals("Rectangle", StringComparison.OrdinalIgnoreCase))//checking the command
                    {
                        abstractShapes ab = factory.getShape("Rectangle");
                        try
                        {
                            par[2] = Convert.ToInt32(hashtable[value[1]]);
                            par[3] = Convert.ToInt32(hashtable[value[2]]);
                           
                        }

                        catch
                        {
                            par[2] = Convert.ToInt32(value[1]);
                            par[3] = Convert.ToInt32(value[2]);
                           
                        }

                        try
                        {
                            par[2] = Convert.ToInt32(value[1]);
                            par[3] = Convert.ToInt32(value[2]);
                           
                        }
                        catch
                        {
                            par[2] = Convert.ToInt32(hashtable[value[1]]);
                            par[3] = Convert.ToInt32(hashtable[value[2]]);
                           
                        }



                        ab.setData(par);
                        ab.drawShape(e.Graphics);
                    }

                    else if (value[0].Equals("var"))
                    {
                        if (value[2].Equals("=") == true && value[4].Equals(";") == true)
                        {
                            int From = line[i].IndexOf("var") + "var".Length;
                            int To = line[i].LastIndexOf("=");

                            String res = line[i].Substring(From, To - From).Replace(" ", String.Empty);

                            int From1 = line[i].IndexOf("=") + "=".Length;
                            int To1 = line[i].LastIndexOf(";");

                            int res1 = Int32.Parse(line[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            try
                            {
                                hashtable.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hashtable[res] = res1;
                            }
                        }
                    }


                    //xaxis



                    if (value[0].Equals("Circle", StringComparison.OrdinalIgnoreCase))
                    {
                        abstractShapes ba = factory.getShape("Circle");
                        try
                        {
                            par[2] = Convert.ToInt32(hashtable[value[1]]);
                            par[3] = Convert.ToInt32(hashtable[value[2]]);
                            
                        }

                        catch
                        {
                            par[2] = Convert.ToInt32(value[1]);
                            par[3] = Convert.ToInt32(value[2]);
                           

                        }

                        try
                        {
                            par[2] = Convert.ToInt32(value[1]);
                            par[3] = Convert.ToInt32(value[2]);
                        
                        }
                        catch
                        {
                            par[2] = Convert.ToInt32(hashtable[value[1]]);
                            par[3] = Convert.ToInt32(hashtable[value[2]]);
                            
                        }
                        ba.setData(par);
                        ba.drawShape(e.Graphics);

                    }
                    else if (value[0].Equals("var"))
                    {
                        if (value[2].Equals("=") == true && value[4].Equals(";") == true)
                        {
                            int From = line[i].IndexOf("var") + "var".Length;
                            int To = line[i].LastIndexOf("=");

                            String res = line[i].Substring(From, To - From).Replace(" ", String.Empty);

                            int From1 = line[i].IndexOf("=") + "=".Length;
                            int To1 = line[i].LastIndexOf(";");

                            int res1 = Int32.Parse(line[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            try
                            {
                                hashtable.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hashtable[res] = res1;
                            }
                        }
                    }

                    if (value[0].Equals("Triangle", StringComparison.OrdinalIgnoreCase))
                    {
                        abstractShapes bac = factory.getShape("Triangle");

                        try
                        {
                            rap[2] = Convert.ToInt32(hashtable[value[1]]);
                            rap[3] = Convert.ToInt32(hashtable[value[2]]);
                            rap[4] = Convert.ToInt32(hashtable[value[3]]);
                            rap[5] = Convert.ToInt32(hashtable[value[4]]);
                        }

                        catch
                        {
                            rap[2] = Convert.ToInt32(value[1]);
                            rap[3] = Convert.ToInt32(value[2]);
                            rap[4] = Convert.ToInt32(value[3]);
                            rap[5] = Convert.ToInt32(value[4]);
                        }

                        try
                        {
                            rap[2] = Convert.ToInt32(value[1]);
                            rap[3] = Convert.ToInt32(value[2]);
                            rap[4] = Convert.ToInt32(value[3]);
                            rap[5] = Convert.ToInt32(value[4]);
                        }
                        catch
                        {
                            rap[2] = Convert.ToInt32(hashtable[value[1]]);
                            rap[3] = Convert.ToInt32(hashtable[value[2]]);
                            rap[4] = Convert.ToInt32(hashtable[value[3]]);
                            rap[5] = Convert.ToInt32(hashtable[value[4]]);
                        }
                        bac.setData(rap);
                        bac.drawShape(e.Graphics);
                    }
                    else if (value[0].Equals("var"))
                    {
                        if (value[2].Equals("=") == true && value[4].Equals(";") == true)
                        {
                            int From = line[i].IndexOf("var") + "var".Length;
                            int To = line[i].LastIndexOf("=");

                            String res = line[i].Substring(From, To - From).Replace(" ", String.Empty);

                            int From1 = line[i].IndexOf("=") + "=".Length;
                            int To1 = line[i].LastIndexOf(";");

                            int res1 = Int32.Parse(line[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            try
                            {
                                hashtable.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hashtable[res] = res1;
                            }
                        }
                    }




                    if (value[0].Equals("POLYGON", StringComparison.OrdinalIgnoreCase))
                    {
                        abstractShapes abs = factory.getShape("POLYGON");

                        try
                        {
                            cab[2] = Convert.ToInt32(hashtable[value[1]]);
                            cab[3] = Convert.ToInt32(hashtable[value[2]]);
                            cab[4] = Convert.ToInt32(hashtable[value[3]]);
                            cab[5] = Convert.ToInt32(hashtable[value[4]]);
                            cab[6] = Convert.ToInt32(hashtable[value[5]]);
                            cab[7] = Convert.ToInt32(hashtable[value[6]]);
                            cab[8] = Convert.ToInt32(hashtable[value[7]]);
                            cab[9] = Convert.ToInt32(hashtable[value[8]]);
                        }

                        catch
                        {
                            cab[2] = Convert.ToInt32(value[1]);
                            cab[3] = Convert.ToInt32(value[2]);
                            cab[4] = Convert.ToInt32(value[3]);
                            cab[5] = Convert.ToInt32(value[4]);
                            cab[6] = Convert.ToInt32(value[5]);
                            cab[7] = Convert.ToInt32(value[6]);
                            cab[8] = Convert.ToInt32(value[7]);
                            cab[9] = Convert.ToInt32(value[8]);
                        }

                        try
                        {
                            cab[2] = Convert.ToInt32(value[1]);
                            cab[3] = Convert.ToInt32(value[2]);
                            cab[4] = Convert.ToInt32(value[3]);
                            cab[5] = Convert.ToInt32(value[4]);
                            cab[6] = Convert.ToInt32(value[5]);
                            cab[7] = Convert.ToInt32(value[6]);
                            cab[8] = Convert.ToInt32(value[7]);
                            cab[9] = Convert.ToInt32(value[8]);
                        }
                        catch
                        {
                            cab[2] = Convert.ToInt32(hashtable[value[1]]);
                            cab[3] = Convert.ToInt32(hashtable[value[2]]);
                            cab[4] = Convert.ToInt32(hashtable[value[3]]);
                            cab[5] = Convert.ToInt32(hashtable[value[4]]);
                            cab[6] = Convert.ToInt32(hashtable[value[5]]);
                            cab[7] = Convert.ToInt32(hashtable[value[6]]);
                            cab[8] = Convert.ToInt32(hashtable[value[7]]);
                            cab[9] = Convert.ToInt32(hashtable[value[8]]);
                        }


                        abs.setData(cab);
                        abs.drawShape(e.Graphics);

                    }
                    else if (value[0].Equals("var"))
                    {
                        if (value[2].Equals("=") == true && value[4].Equals(";") == true)
                        {
                            int From = line[i].IndexOf("var") + "var".Length;
                            int To = line[i].LastIndexOf("=");

                            String res = line[i].Substring(From, To - From).Replace(" ", String.Empty);

                            int From1 = line[i].IndexOf("=") + "=".Length;
                            int To1 = line[i].LastIndexOf(";");

                            int res1 = Int32.Parse(line[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            try
                            {
                                hashtable.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hashtable[res] = res1;
                            }
                        }
                    }


                    if (value[0].Equals("Texture", StringComparison.OrdinalIgnoreCase))//checking the command
                    {
                        abstractShapes ab = factory.getShape("Texture");
                        try
                        {
                            par[2] = Convert.ToInt32(hashtable[value[1]]);
                            par[3] = Convert.ToInt32(hashtable[value[2]]);
                        }

                        catch
                        {
                            par[2] = Convert.ToInt32(value[1]);
                            par[3] = Convert.ToInt32(value[2]);

                        }

                        try
                        {
                            par[2] = Convert.ToInt32(value[1]);
                            par[3] = Convert.ToInt32(value[2]);
                        }
                        catch
                        {
                            par[2] = Convert.ToInt32(hashtable[value[1]]);
                            par[3] = Convert.ToInt32(hashtable[value[2]]);
                        }



                        ab.setData(par);
                        ab.drawShape(e.Graphics);
                    }

                    else if (value[0].Equals("var"))
                    {
                        if (value[2].Equals("=") == true && value[4].Equals(";") == true)
                        {
                            int From = line[i].IndexOf("var") + "var".Length;
                            int To = line[i].LastIndexOf("=");

                            String res = line[i].Substring(From, To - From).Replace(" ", String.Empty);

                            int From1 = line[i].IndexOf("=") + "=".Length;
                            int To1 = line[i].LastIndexOf(";");

                            int res1 = Int32.Parse(line[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            try
                            {
                                hashtable.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hashtable[res] = res1;
                            }
                        }
                    }

           
                    if (value[0].Equals("Line", StringComparison.OrdinalIgnoreCase))//checking the command
                    {
                        MessageBox.Show("hello");
                        abstractShapes ab = factory.getShape("Line");
                        try
                        {
                            par[2] = Convert.ToInt32(hashtable[value[1]]);
                            par[3] = Convert.ToInt32(hashtable[value[2]]);

                        }

                        catch
                        {
                            par[2] = Convert.ToInt32(value[1]);
                            par[3] = Convert.ToInt32(value[2]);

                        }

                        try
                        {
                            par[2] = Convert.ToInt32(value[1]);
                            par[3] = Convert.ToInt32(value[2]);

                        }
                        catch
                        {
                            par[2] = Convert.ToInt32(hashtable[value[1]]);
                            par[3] = Convert.ToInt32(hashtable[value[2]]);

                        }



                        ab.setData(par);
                        ab.drawShape(e.Graphics);
                    }

                    else if (value[0].Equals("var"))
                    {
                        if (value[2].Equals("=") == true && value[4].Equals(";") == true)
                        {
                            int From = line[i].IndexOf("var") + "var".Length;
                            int To = line[i].LastIndexOf("=");

                            String res = line[i].Substring(From, To - From).Replace(" ", String.Empty);

                            int From1 = line[i].IndexOf("=") + "=".Length;
                            int To1 = line[i].LastIndexOf(";");

                            int res1 = Int32.Parse(line[i].Substring(From1, To1 - From1).Replace(" ", String.Empty));
                            try
                            {
                                hashtable.Add(res, res1);
                            }
                            catch (Exception x)
                            {
                                hashtable[res] = res1;
                            }
                        }
                    }





                    if (value[0].Equals("Repeat", StringComparison.OrdinalIgnoreCase) || value[0].Equals("Loop", StringComparison.OrdinalIgnoreCase))
                    {
                        //initializing new parameter for rectangle and circle
                        int[] newpar = new int[4];
                        //initializing new parameter triangle
                        int[] tnewpar = new int[6];

                        //for rectangle
                        if (value[2].Equals("rectangle", StringComparison.OrdinalIgnoreCase))
                        {
                            for (int x = 0; x < Convert.ToInt32(value[1]) - 1; x++)
                            {
                                if (value[3].Equals("+"))
                                {
                                    int add = Convert.ToInt32(value[4]);
                                    abstractShapes abs = factory.getShape("Rectangle");//calling instance of rectangle
                                    if (x == 0)
                                    {
                                        newpar[0] = par[0];
                                        newpar[1] = par[1];
                                        newpar[2] = par[2] + add;
                                        newpar[3] = par[3] + add;
                                    }
                                    else
                                    {
                                        newpar[0] = newpar[0];
                                        newpar[1] = newpar[1];
                                        newpar[2] = newpar[2] + add;
                                        newpar[3] = newpar[3] + add;
                                    }
                                    abs.setData(newpar);
                                    abs.drawShape(e.Graphics);

                                }
                                else if (value[3].Equals("-"))
                                {
                                    int subtract = Convert.ToInt32(value[4]);
                                    abstractShapes abs = factory.getShape("Rectangle");
                                    if (x == 0)
                                    {
                                        newpar[0] = par[0];
                                        newpar[1] = par[1];
                                        newpar[2] = par[2] - subtract;
                                        newpar[3] = par[3] - subtract;
                                    }
                                    else
                                    {
                                        newpar[0] = newpar[0];
                                        newpar[1] = newpar[1];
                                        newpar[2] = newpar[2] - subtract;
                                        newpar[3] = newpar[3] - subtract;
                                    }
                                    abs.setData(newpar);
                                    abs.drawShape(e.Graphics);
                                }
                               


                            }
                        }

                        //for circle
                        if (value[2].Equals("circle", StringComparison.OrdinalIgnoreCase))
                        {
                            for (int x = 0; x < Convert.ToInt32(value[1]) - 1; x++)
                            {
                                if (value[3].Equals("+"))
                                {
                                    int add = Convert.ToInt32(value[4]);
                                    abstractShapes abs = factory.getShape("circle");//calling factory intance
                                    if (x == 0)
                                    {
                                        newpar[0] = par[0];
                                        newpar[1] = par[1];
                                        newpar[2] = par[2] + add;
                                        newpar[3] = par[3] + add;
                                    }
                                    else
                                    {
                                        newpar[0] = newpar[0];
                                        newpar[1] = newpar[1];
                                        newpar[2] = newpar[2] + add;
                                        newpar[3] = newpar[3] + add;
                                    }
                                    abs.setData(newpar);
                                    abs.drawShape(e.Graphics);

                                }
                                else if (value[3].Equals("-"))
                                {
                                    int subtract = Convert.ToInt32(value[4]);
                                    abstractShapes abs = factory.getShape("circle");
                                    if (x == 0)
                                    {
                                        newpar[0] = newpar[0];
                                        newpar[1] = newpar[1];
                                        newpar[2] = newpar[2] - subtract;
                                        newpar[3] = newpar[3] - subtract;
                                    }
                                    else
                                    {
                                        newpar[0] = newpar[0];
                                        newpar[1] = newpar[1];
                                        newpar[2] = newpar[2] - subtract;
                                        newpar[3] = newpar[3] - subtract;
                                    }
                                    abs.setData(newpar);
                                    abs.drawShape(e.Graphics);
                                }

                            }
                        }

                        //for triangle
                        if (value[2].Equals("Triangle", StringComparison.OrdinalIgnoreCase))
                        {
                            for (int x = 0; x < Convert.ToInt32(value[1]) - 1; x++)
                            {
                                if (value[3].Equals("+"))
                                {
                                    int add = Convert.ToInt32(value[4]);
                                    abstractShapes abs = factory.getShape("triangle");
                                    if (x == 0)
                                    {
                                        tnewpar[0] = rap[0] + add;
                                        tnewpar[1] = rap[1];
                                        tnewpar[2] = rap[2] + add;
                                        tnewpar[3] = rap[3];
                                        tnewpar[4] = rap[4] + add;
                                        tnewpar[5] = rap[5];
                                    }
                                    else
                                    {
                                        tnewpar[0] = tnewpar[0] + add;
                                        tnewpar[1] = tnewpar[1];
                                        tnewpar[2] = tnewpar[2] + add;
                                        tnewpar[3] = tnewpar[3];
                                        tnewpar[4] = tnewpar[4] + add;
                                        tnewpar[5] = tnewpar[5];
                                    }
                                    abs.setData(tnewpar);
                                    abs.drawShape(e.Graphics);

                                }
                                else if (value[3].Equals("-"))
                                {
                                    int subtract = Convert.ToInt32(value[4]);
                                    abstractShapes abs = factory.getShape("triangle");
                                    if (x == 0)
                                    {
                                        tnewpar[0] = rap[0] - subtract;
                                        tnewpar[1] = rap[1];
                                        tnewpar[2] = rap[2] - subtract;
                                        tnewpar[3] = rap[3];
                                        tnewpar[4] = rap[4] - subtract;
                                        tnewpar[5] = rap[5];
                                    }
                                    else
                                    {
                                        tnewpar[0] = tnewpar[0] - subtract;
                                        tnewpar[1] = tnewpar[1];
                                        tnewpar[2] = tnewpar[2] - subtract;
                                        tnewpar[3] = tnewpar[3];
                                        tnewpar[4] = tnewpar[4] - subtract;
                                        tnewpar[5] = tnewpar[5];
                                    }
                                    abs.setData(tnewpar);
                                    abs.drawShape(e.Graphics);
                                }
                              
                            }
                        }
                        if (value[2].Equals("Polygon", StringComparison.OrdinalIgnoreCase))
                        {
                            for (int x = 0; x < Convert.ToInt32(value[1]) - 1; x++)
                            {
                                if (value[3].Equals("+"))
                                {
                                    int add = Convert.ToInt32(value[4]);
                                    abstractShapes abs = factory.getShape("Polygon");
                                    if (x == 0)
                                    {
                                        tnewpar[0] = cab[0];
                                        tnewpar[1] = cab[1];
                                        tnewpar[2] = cab[2] + add;
                                        tnewpar[3] = cab[3];
                                        tnewpar[4] = cab[4] + add;
                                        tnewpar[5] = cab[5];
                                        tnewpar[6] = cab[6];
                                        tnewpar[7] = cab[7] + add;
                                        tnewpar[8] = cab[8];
                                        tnewpar[9] = cab[9];
                                    }
                                    else
                                    {
                                        tnewpar[0] = cab[0];
                                        tnewpar[1] = cab[1];
                                        tnewpar[2] = cab[2] + add;
                                        tnewpar[3] = cab[3];
                                        tnewpar[4] = cab[4] + add;
                                        tnewpar[5] = cab[5];
                                        tnewpar[6] = cab[6];
                                        tnewpar[7] = cab[7] + add;
                                        tnewpar[8] = cab[8];
                                        tnewpar[9] = cab[9];
                                    }
                                    abs.setData(tnewpar);
                                    abs.drawShape(e.Graphics);

                                }
                                else if (value[3].Equals("-"))
                                {
                                    int subtract = Convert.ToInt32(value[4]);
                                    abstractShapes abs = factory.getShape("Polygon");
                                    if (x == 0)
                                    {
                                        tnewpar[0] = cab[0] - subtract;
                                        tnewpar[1] = cab[1];
                                        tnewpar[2] = cab[2] - subtract;
                                        tnewpar[3] = cab[3];
                                        tnewpar[4] = cab[4] - subtract;
                                        tnewpar[5] = cab[5];
                                        tnewpar[6] = cab[6];
                                        tnewpar[7] = cab[7] - subtract;
                                        tnewpar[8] = cab[8];
                                        tnewpar[9] = cab[9];
                                    }
                                    else
                                    {
                                        tnewpar[0] = cab[0] - subtract;
                                        tnewpar[1] = cab[1];
                                        tnewpar[2] = cab[2] - subtract;
                                        tnewpar[3] = cab[3];
                                        tnewpar[4] = cab[4] - subtract;
                                        tnewpar[5] = cab[5];
                                        tnewpar[6] = cab[6];
                                        tnewpar[7] = cab[7] - subtract;
                                        tnewpar[8] = cab[8];
                                        tnewpar[9] = cab[9];
                                    }
                                    abs.setData(tnewpar);
                                    abs.drawShape(e.Graphics);
                                }
                               
                            }
                        }
                    }

                    int[] d = new int[2];

                    //start
                    //loop command

                    if (value[0].Equals("Loop", StringComparison.OrdinalIgnoreCase))
                    {
                        
                        counter = Convert.ToInt32(value[1]);
                    }
                    //loop command for rectangle 
                    if (value[0].Equals("Rectangl", StringComparison.OrdinalIgnoreCase))
                    {
                   
                        store = "Rectangle";
                        par2[0] = Convert.ToInt32(value[1]);
                        par2[1] = Convert.ToInt32(value[2]);
                    }

                    //loop command for circle
                    if (value[0].Equals("circl", StringComparison.OrdinalIgnoreCase))
                    {
                 
                        store = "Circle";
                        par2[0] = Convert.ToInt32(value[1]);
                        par2[1] = Convert.ToInt32(value[2]);

                    }
                    //loop command for triangle
                    if (value[0].Equals("triangl", StringComparison.OrdinalIgnoreCase))
                    {
                      
                        store = "Triangle";
                        par3[0] = Convert.ToInt32(value[1]);
                        par3[1] = Convert.ToInt32(value[2]);
                        par3[2] = Convert.ToInt32(value[3]);
                        par3[3] = Convert.ToInt32(value[4]);

                    }
                    //collecting width
                    if (value[0].Equals("width", StringComparison.OrdinalIgnoreCase))
                    {
                        width = Convert.ToInt32(value[2]);
               
                    }
                    //collecting height
                    if (value[0].Equals("height", StringComparison.OrdinalIgnoreCase))
                    {
                        height = Convert.ToInt32(value[2]);
                        
                    }
                    //collecting radius
                    if (value[0].Equals("radius", StringComparison.OrdinalIgnoreCase))
                    {
                        radius1 = Convert.ToInt32(value[2]);
                       
                    }
                    //collecting base 
                    if (value[0].Equals("p", StringComparison.OrdinalIgnoreCase))
                    {
                        p = Convert.ToInt32(value[2]);
                 
                    }
                    //collecting hypotenuse 
                    if (value[0].Equals("h", StringComparison.OrdinalIgnoreCase))
                    {
                        h = Convert.ToInt32(value[2]);
                        
                    }


                    //endloop
                    if (value[0].Equals("endloop", StringComparison.OrdinalIgnoreCase))
                    {
                        //checking rec
                        if (store.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))

                        {

                            for (int y = 0; y < counter; y++)
                            {
                           
                                //intance of abstract class
                                abstractShapes abs = factory.getShape("Rectangle");
                                if (y == 0)
                                {
                                    par[2] = par2[0] + width;
                                    par[3] = par2[1] + height;
                                }
                                else
                                {
                                    par[2] = par[2] + width;
                                    par[3] = par[3] + height;
                                }
                                abs.setData(par);
                                abs.drawShape(e.Graphics);
                            }
                        }
                        //checking cir
                        if (store.Equals("Circle", StringComparison.OrdinalIgnoreCase))

                        {

                            for (int y = 0; y < counter; y++)
                            {
                                
                                //intance of abstract class
                                abstractShapes abs = factory.getShape("Circle");
                                if (y == 0)
                                {
                                    par[2] = par2[0] + radius1;
                                    par[3] = par2[1] + radius1;
                                }
                                else
                                {
                                    par[2] = par[2] + radius1;
                                    par[3] = par[3] + radius1;
                                }
                                abs.setData(par);
                                abs.drawShape(e.Graphics);
                            }
                        }
                        //checking for tri
                        if (store.Equals("Triangle", StringComparison.OrdinalIgnoreCase))

                        {

                            for (int y = 0; y < counter; y++)
                            {
                    
                                //intance of abstract class
                                abstractShapes abs = factory.getShape("Triangle");
                                if (y == 0)
                                {
                                    rap[2] = par3[0] + p;
                                    rap[3] = par3[1] + p;
                                    rap[4] = par3[2] + h;
                                    rap[5] = par3[3] + h;
                                }
                                else
                                {
                                    rap[2] = rap[2] + p;
                                    rap[3] = rap[3] + p;
                                    rap[4] = rap[4] + h;
                                    rap[5] = rap[5] + h;
                                }
                                abs.setData(rap);
                                abs.drawShape(e.Graphics);
                            }
                        }

                    }

                    //end

                    //start
                    //for if command

                    if (value[0].Equals("if"))
                    {

                        if (counter == Convert.ToInt32(value[3]))
                        {
                            if (value[5].Equals("radius", StringComparison.OrdinalIgnoreCase))
                            {
                                radius1 = Convert.ToInt32(value[7]);
                                
                            }

                            if (value[5].Equals("width", StringComparison.OrdinalIgnoreCase))
                            {
                                width = Convert.ToInt32(value[7]);
                             
                            }

                            if (value[5].Equals("height", StringComparison.OrdinalIgnoreCase))
                            {
                                height = Convert.ToInt32(value[7]);
                                
                            }
                        }
                    }


                    //emd

                    int ifcounter = 0;
                    //start
                    //if full  command
                    if (value[0].Equals("IF"))
                    {
                        ifcounter = Convert.ToInt32(value[3]);
                    }

                    if (value[0].Equals("endIf", StringComparison.OrdinalIgnoreCase))
                    {
                        if (counter == ifcounter)
                        {
                            //checking rec
                            if (store.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))

                            {

                                for (int y = 0; y < counter; y++)
                                {
                                    MessageBox.Show("inside loop");
                                    //intance of abstract class
                                    abstractShapes abs = factory.getShape("Rectangle");
                                    if (y == 0)
                                    {
                                        par[2] = par2[0] + width;
                                        par[3] = par2[1] + height;

                                    }
                                    else
                                    {
                                        par[2] = par[2] + width;
                                        par[3] = par[3] + height;

                                    }
                                    abs.setData(par);
                                    abs.drawShape(e.Graphics);
                                }
                            }

                            //checking cir
                            if (store.Equals("Circle", StringComparison.OrdinalIgnoreCase))

                            {

                                for (int y = 0; y < counter; y++)
                                {
                            
                                    //intance of abstract class
                                    abstractShapes abs = factory.getShape("Circle");
                                    if (y == 0)
                                    {
                                        par[2] = par2[0] + radius1;
                                        par[3] = par2[1] + radius1;
                                    }
                                    else
                                    {
                                        par[2] = par[2] + radius1;
                                        par[3] = par[3] + radius1;
                                    }
                                    abs.setData(par);
                                    abs.drawShape(e.Graphics);
                                }
                            }

                        }
                    }
                    

                }
                else
                {
                    throw new errorCatch();
                }
                //end


            }
        }
       
        private void button1_Click_2(object sender, EventArgs e)
            {
                edit.Clear(); //clear
               panel1.Invalidate();//clear

            }
        }
    }



    


