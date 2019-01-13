using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeInterface
{
    /// <summary>
    /// variable declaration
    /// </summary>
    public partial class Feature : Form
    {
        Graphics g;
        Pen pe;
        int x = -1;
        int y = -1;
        bool move;
/// <summary>
/// featuee
/// </summary>
        public Feature()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            pe = new Pen(Color.Red,3);  
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender; //click event
            pe.Color = p.BackColor; //color
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move && x != -1 && y !=-1)
            {
                g.DrawLine(pe,new Point(x,y),e.Location);
                x = e.X;
                y = e.Y;
                
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
            x = -1;
            y = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap image1 = (Bitmap)Image.FromFile(@"E:\study\ShapeandDraw\ShapeInterface\ShapeInterface\Resources\lace.bmp", true);

            TextureBrush texture = new TextureBrush(image1);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(texture,
                new RectangleF(90.0F, 110.0F, 100, 100));
            formGraphics.Dispose();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            button1.Text = "Erase";
        }
    }
    }

