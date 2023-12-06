using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Hog_Jumper.DBFolder
{
    internal class ConnectionString
    {
        public static string ConnectStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Hog_Jumper.Properties.Settings.ConnectionString"].ConnectionString;
            }
            
        }
    }
}
