using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playstation_Friends_List
{
    public class ApplicationSettings
    {
        private string username = string.Empty;
        public string Username { get { return username; } set { username = value; } }
        private string password = string.Empty;
        public string Password { get { return password; } set { password = value; } }
    }
    public class Settings
    {
      
        private static ApplicationSettings application;
        public static ApplicationSettings Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }

    }
}
