﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hog_Jumper
{
    class MyApplicationContext : ApplicationContext
    {
        public MyApplicationContext()
        {
            Form7 form7 = new Form7();
            form7.Show();
        }
    }
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyApplicationContext context = new MyApplicationContext();
            Application.Run(context);
        }
    }
}
