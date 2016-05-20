using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace Playstation_Friends_List
{
    public partial class FormMain : Form
    {
      public PlaystationConnections psnConnection;
        ImageList imglist = new ImageList();
        #region Public 
        public void addMarquee(string message)
        {
            marqueeLable.AddMessage(message); 
        }
        public void accountName(string message)
        {
            lblAccount.Invoke(new MethodInvoker(() => { lblAccount.Text = message; }));
        }
        public void avatarPic(string url)
        {
            picAvatar.ImageLocation = url;
        }
        private Image LoadImage(string url)
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(url);

            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();

            Bitmap bmp = new Bitmap(responseStream);

            responseStream.Dispose();

            return bmp;
        }
        public void FriendList(string UserName,string Avatar,string Online
            ,string platForm,string gameTitle,string gamestatus)
        {
            friendList.Columns.AddRange(new ColumnHeader[]
           {new ColumnHeader(), new ColumnHeader(), new ColumnHeader(),new ColumnHeader(),new ColumnHeader()});
            friendList.View = View.Tile;
            imglist.ImageSize = new Size(48, 48);
            imglist.ColorDepth = ColorDepth.Depth32Bit;
            imglist.Images.Add(UserName, LoadImage(Avatar));
            friendList.LargeImageList = imglist;
            friendList.TileSize = new Size(220, 85);
            
            for (int i = 0; i < imglist.Images.Count; i++)
            {
                if (imglist.Images.Keys[i].Contains(UserName))
                {
                    ListViewItem items = new ListViewItem();
                    
                    items.ImageIndex = i;
                    items.Text = UserName;
                    items.SubItems.Add(Online);
                    items.SubItems.Add(platForm);
                    items.SubItems.Add(gameTitle);
                    items.SubItems.Add(gamestatus);
                    friendList.Invoke((MethodInvoker)delegate { friendList.Items.Add(items); });
                    break;
                }
            }
        }
        #endregion
        private FormSignIn signInWindow;
        public  FormSignIn SignInWindow
        {
            get { return signInWindow; }
            set { signInWindow = value; }
        }
        public FormMain()
        {
            InitializeComponent();
            signInWindow = new FormSignIn();
            signInWindow.Show();
            signInWindow.TopMost =true;
            addMarquee("Status: Loaded, Please Sign In with Playstation Account");
           
        }
      
        private void FormMain_Load(object sender, EventArgs e)
        {
            psnConnection = new PlaystationConnections();
        }
        
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            signInWindow = new FormSignIn();
            signInWindow.Show();
            signInWindow.TopMost = true;
            friendList.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnMessage_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
