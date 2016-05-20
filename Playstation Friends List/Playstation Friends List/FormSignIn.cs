using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playstation_Friends_List
{
    public partial class FormSignIn : Form
    {
        public FormSignIn()
        {
            InitializeComponent();
            Settings.Application = (ApplicationSettings)Serialization.Load("ApplicationSettings", typeof(ApplicationSettings));
            if (Settings.Application == null)
                Settings.Application = new ApplicationSettings();
            textUser.Text = Settings.Application.Username;
            textPassword.Text = Settings.Application.Password;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
          string response =  Program.MainWindow.psnConnection.PlaystationCookie(textUser.Text, textPassword.Text);
            if (response.Contains("error"))
                MessageBox.Show(string.Format("{0}\r\n{1}", "Invalid Username/Password", "please try again, make sure you have a playstation account"), "Invalid Username/Password");
            Application.DoEvents();
           
            SaveSetting();
           
           
        }

        public void SaveSetting()
        {
            Settings.Application.Username = textUser.Text;
            Settings.Application.Password = textPassword.Text;
            Serialization.Save("ApplicationSettings", typeof(ApplicationSettings), Settings.Application);
        }

        private void FormSignIn_Load(object sender, EventArgs e)
        {
            
          
        }

        private void FormSignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSetting();
        }
    }
}
