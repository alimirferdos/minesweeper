using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    class Cell
    {
        public Button b;
        public bool bomb=false;
        public Form1 f;
        static Random r = new Random();
        Cell[,] c;
        private int x, y;
        public bool vflag = false;

        int around
        {
            get
            {
                int count = 0;
                for (int i = - 1; i <= 1; i++)
                {
                    for (int j = - 1; j <= 1; j++)
                    {
                        try
                        {
                            //if (i != x && j != y)
                                if (c[x+i, y+j].bomb)
                                    count++;
                        }
                        catch { }
                    }
                }
                return count;
            }
        }
        public Cell(int x, int y, Form1 f, Cell[,] c, double chance = 0.15)
        {
            this.x = x;
            this.y = y;
            this.c = c;
            this.f = f;
            b = new Button();
            b.Width = 50;
            b.Height = 50;
            b.Top = 51 * x;
            b.Left = 51 * y;
            f.Controls.Add(b);
            if (r.NextDouble() < chance)
                bomb = true;
            b.MouseDown += new MouseEventHandler(b_MouseDown);

        }


        public void b_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (c[x,y].b.Text !="FLAG")
                {
                    
                
                vflag = true;
                b.Enabled = false;
                if (c[x, y].bomb)
                {

                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                            if (c[i, j].bomb)
                                c[i, j].b.Text = "BOOM";
                    MessageBox.Show("Sorry ... ");
                    f.Close();
                }
                else
                {
                    b.Enabled = false;
                    int a = around;
                    if (a != 0)
                        b.Text = a.ToString();
                    else
                        for (int i = - 1; i <= 1; i++)
                            for (int j = - 1; j <= 1; j++)
                            {
                                try
                                {
                                    // x+i != x && y+j != y && 
                                    if (c[x+i, y+j].vflag==false)
                                        c[x+i, y+j].b_MouseDown(c[x+i, y+j].b, e);

                                }
                                catch { }
                            }
                }
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                if (c[x, y].b.Text == "FLAG")
                {
                    c[x, y].b.Text = "?";
                }
                else if (c[x, y].b.Text == "?")
                {
                    c[x, y].b.Text = "";
                }
                else 
                {
                    c[x, y].b.Text = "FLAG";
                }

            }
            
        }


    }
}
