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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cell [,]c = new Cell[10, 10];
            int xx = 10, yy = 10;
            //int nn = 0 , bb=0;
            
            for (int i = 0; i < yy; i++) {
                for (int j = 0; j < xx; j++)
                {
                    c[i,j] = new Cell(i, j, this, c);
                }
               /* for (int m = 0; m < yy; m++)
                {
                    for (int j = 0; j < xx; j++)
                    {
                        if (c[m, j].b.Enabled==true)
                            nn++;
                        if (c[m, j].bomb==true)
                            bb++;

                        
                    }
                    
                }
                if (bb == nn)
                {   
                    MessageBox.Show("You win"); 
                    //Form1_Load.Close();
                }
                */

            }
        }
    }
}
