namespace Playstation_Friends_List
    {
    partial class FormMain
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSignIn = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnMessage = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAccount = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.friendList = new System.Windows.Forms.ListView();
            this.marqueeLable = new Playstation_Friends_List.MarqueeControl();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSignIn,
            this.btnSearch,
            this.btnMessage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(330, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btnSignIn
            // 
            this.btnSignIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSignIn.Image = ((System.Drawing.Image)(resources.GetObject("btnSignIn.Image")));
            this.btnSignIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(23, 22);
            this.btnSignIn.ToolTipText = "Sign In";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.ToolTipText = "Search For User";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnMessage.Image")));
            this.btnMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(23, 22);
            this.btnMessage.ToolTipText = "Check Messages";
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAccount);
            this.panel1.Controls.Add(this.picAvatar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 61);
            this.panel1.TabIndex = 20;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(76, 29);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(0, 13);
            this.lblAccount.TabIndex = 1;
            // 
            // picAvatar
            // 
            this.picAvatar.Location = new System.Drawing.Point(12, 5);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(50, 50);
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // friendList
            // 
            this.friendList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.friendList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendList.FullRowSelect = true;
            this.friendList.HideSelection = false;
            this.friendList.Location = new System.Drawing.Point(0, 86);
            this.friendList.MultiSelect = false;
            this.friendList.Name = "friendList";
            this.friendList.Size = new System.Drawing.Size(330, 394);
            this.friendList.TabIndex = 21;
            this.friendList.UseCompatibleStateImageBehavior = false;
            this.friendList.View = System.Windows.Forms.View.Tile;
            // 
            // marqueeLable
            // 
            this.marqueeLable._Height = 34;
            this.marqueeLable._Size = new System.Drawing.Size(330, 34);
            this.marqueeLable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.marqueeLable.DistanceFromEdge = 10;
            this.marqueeLable.DistanceToMove = 1;
            this.marqueeLable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.marqueeLable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marqueeLable.Interval = 20;
            this.marqueeLable.LinkColor = System.Drawing.Color.Blue;
            this.marqueeLable.LinkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.marqueeLable.Location = new System.Drawing.Point(0, 480);
            this.marqueeLable.Name = "marqueeLable";
            this.marqueeLable.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.marqueeLable.Size = new System.Drawing.Size(330, 34);
            this.marqueeLable.TabIndex = 0;
            this.marqueeLable.TickerInterval = 3000;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 514);
            this.Controls.Add(this.friendList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.marqueeLable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Playstation Messanger";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private MarqueeControl marqueeLable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSignIn;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.ListView friendList;
    }
    }

