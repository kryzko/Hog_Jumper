﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hog_Jumper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0) { MessageBox.Show("Сигма"); }
            if (i == 1) { MessageBox.Show("СССИИИСЬКИ"); i = -1; }
            i++;
        }
    }
}
