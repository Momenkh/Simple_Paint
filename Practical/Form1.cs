using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical
{
    public partial class Form1 : Form
    {
        Pen DrawPen;
        Point A;
        Point B;
        Color DrawClr;
        float Thickness;
        int drawChoice;
        bool isMouseDown;

        public Form1()
        {
            InitializeComponent();
            DrawClr = Color.Black;
            Thickness= 1;
            drawChoice = 0;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBorder();
            Update();
        }
        public void DrawBorder()
        {
            Graphics g = this.CreateGraphics();
            Pen X = new Pen(Color.Black, 2);
            g.DrawRectangle(X, 50, 150,1800, 800);
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        } // FILE MENUSTRIP

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Format = new Form2();
            Format.Clr = DrawClr;
            Format.Thick = Thickness;

            DialogResult FormatResult = Format.ShowDialog();
            if (FormatResult == DialogResult.OK)
            {
                Thickness = Format.Thick;
                DrawClr = Format.Clr;
                Update();
            }
        } // FORMAT MENUSTRIP

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawChoice= 0;
            Update();
        } // SHAPE MENUSTRIP
        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawChoice = 1;
            Update();
        }
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawChoice = 2;
            Update();
        }
        private void freeHandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawChoice = 3;
            Update();
        }

        private void Draw(Point XX, Point YY) {
            Graphics G = this.CreateGraphics();
            DrawPen = new Pen(DrawClr, Thickness);
            Rectangle R;
            if (drawChoice != 0)
            {
                if (YY.X < XX.X)
                {
                    Point Temp = XX;
                    XX.X = YY.X;
                    YY.X = Temp.X;
                }
                if (YY.Y < XX.Y)
                {
                    Point Temp = XX;
                    XX.Y = YY.Y;
                    YY.Y = Temp.Y;
                }
            }
            switch (drawChoice) 
            {
                case 0: 
                    G.DrawLine(DrawPen, XX, YY);
                    break;
                case 1:
                    R = new Rectangle(XX.X, XX.Y, YY.X - XX.X, YY.Y - XX.Y);
                    G.DrawEllipse(DrawPen, R);
                    break;
                case 2:  
                    R = new Rectangle(XX.X,XX.Y,YY.X-XX.X,YY.Y-XX.Y);
                    G.DrawRectangle(DrawPen, R);
                    break;
                case 3:
                    break;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        { 
            A = e.Location;
            isMouseDown= true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            B = e.Location;
            Draw(A, B);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMouseDown==true && drawChoice==3)
            {
                Graphics G = this.CreateGraphics();
                DrawPen = new Pen(DrawClr, Thickness);
                B = e.Location;
                G.DrawLine(DrawPen, A, B);
                A = B;
            }
        }
        private void Update() {
            string str = "";
            str += "Color: " + DrawClr.ToString() + " ,Thickness: " + Thickness + " ,Style: ";
            switch (drawChoice) 
            { 
                case 0:
                    str += "Line";
                    break;
                case 1:
                    str += "Circle";
                    break;
                case 2:
                    str += "Rectangle";
                    break;
                case 3:
                    str += "Free-Hand";
                    break;
            }
            toolStripStatusLabel1.Text = str;
        }
    }
}
