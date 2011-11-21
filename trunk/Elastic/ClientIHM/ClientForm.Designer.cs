namespace ClientIHM
{
    partial class ClientForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabServiceInfo = new System.Windows.Forms.TabPage();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lbService = new System.Windows.Forms.Label();
            this.btnRequest = new System.Windows.Forms.Button();
            this.tbService = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btnReach = new System.Windows.Forms.Button();
            this.dgvServicesInfo = new System.Windows.Forms.DataGridView();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabService = new System.Windows.Forms.TabPage();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnSend100 = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabServiceInfo.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesInfo)).BeginInit();
            this.tabService.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(419, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "&Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "&Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabServiceInfo);
            this.tabControl.Controls.Add(this.tabService);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(419, 401);
            this.tabControl.TabIndex = 1;
            // 
            // tabServiceInfo
            // 
            this.tabServiceInfo.Controls.Add(this.groupBox);
            this.tabServiceInfo.Controls.Add(this.lbInfo);
            this.tabServiceInfo.Controls.Add(this.btnReach);
            this.tabServiceInfo.Controls.Add(this.dgvServicesInfo);
            this.tabServiceInfo.Location = new System.Drawing.Point(4, 22);
            this.tabServiceInfo.Name = "tabServiceInfo";
            this.tabServiceInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabServiceInfo.Size = new System.Drawing.Size(411, 375);
            this.tabServiceInfo.TabIndex = 0;
            this.tabServiceInfo.Text = "Services Information";
            this.tabServiceInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lbService);
            this.groupBox.Controls.Add(this.btnRequest);
            this.groupBox.Controls.Add(this.tbService);
            this.groupBox.Location = new System.Drawing.Point(8, 6);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(395, 54);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Requesting Service";
            // 
            // lbService
            // 
            this.lbService.AutoSize = true;
            this.lbService.Location = new System.Drawing.Point(22, 22);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(74, 13);
            this.lbService.TabIndex = 3;
            this.lbService.Text = "Service Name";
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(282, 10);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(96, 37);
            this.btnRequest.TabIndex = 5;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // tbService
            // 
            this.tbService.Location = new System.Drawing.Point(131, 19);
            this.tbService.Name = "tbService";
            this.tbService.Size = new System.Drawing.Size(125, 20);
            this.tbService.TabIndex = 4;
            // 
            // lbInfo
            // 
            this.lbInfo.Location = new System.Drawing.Point(136, 78);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(250, 13);
            this.lbInfo.TabIndex = 2;
            // 
            // btnReach
            // 
            this.btnReach.Location = new System.Drawing.Point(304, 330);
            this.btnReach.Name = "btnReach";
            this.btnReach.Size = new System.Drawing.Size(96, 37);
            this.btnReach.TabIndex = 1;
            this.btnReach.Text = "Reach Service";
            this.btnReach.UseVisualStyleBackColor = true;
            this.btnReach.Click += new System.EventHandler(this.btnReach_Click);
            // 
            // dgvServicesInfo
            // 
            this.dgvServicesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicesInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Service,
            this.Title,
            this.IPAddress,
            this.Port});
            this.dgvServicesInfo.Location = new System.Drawing.Point(3, 94);
            this.dgvServicesInfo.MultiSelect = false;
            this.dgvServicesInfo.Name = "dgvServicesInfo";
            this.dgvServicesInfo.Size = new System.Drawing.Size(397, 227);
            this.dgvServicesInfo.TabIndex = 0;
            // 
            // Service
            // 
            this.Service.HeaderText = "Service";
            this.Service.Name = "Service";
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            // 
            // IPAddress
            // 
            this.IPAddress.HeaderText = "IP Address";
            this.IPAddress.Name = "IPAddress";
            // 
            // Port
            // 
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            // 
            // tabService
            // 
            this.tabService.Controls.Add(this.btnSend100);
            this.tabService.Controls.Add(this.btnSend);
            this.tabService.Controls.Add(this.rtbInput);
            this.tabService.Controls.Add(this.rtbDisplay);
            this.tabService.Location = new System.Drawing.Point(4, 22);
            this.tabService.Name = "tabService";
            this.tabService.Padding = new System.Windows.Forms.Padding(3);
            this.tabService.Size = new System.Drawing.Size(411, 375);
            this.tabService.TabIndex = 1;
            this.tabService.Text = "Service Action";
            this.tabService.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(312, 293);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 38);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtbInput
            // 
            this.rtbInput.Location = new System.Drawing.Point(9, 235);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(276, 96);
            this.rtbInput.TabIndex = 1;
            this.rtbInput.Text = "test";
            this.rtbInput.TextChanged += new System.EventHandler(this.rtbInput_TextChanged);
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.BackColor = System.Drawing.Color.White;
            this.rtbDisplay.Location = new System.Drawing.Point(9, 7);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.ReadOnly = true;
            this.rtbDisplay.Size = new System.Drawing.Size(276, 207);
            this.rtbDisplay.TabIndex = 0;
            this.rtbDisplay.Text = "";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnSend100
            // 
            this.btnSend100.Location = new System.Drawing.Point(312, 235);
            this.btnSend100.Name = "btnSend100";
            this.btnSend100.Size = new System.Drawing.Size(91, 38);
            this.btnSend100.TabIndex = 3;
            this.btnSend100.Text = "Send 100s";
            this.btnSend100.UseVisualStyleBackColor = true;
            this.btnSend100.Click += new System.EventHandler(this.btnSend100_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(419, 425);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabServiceInfo.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesInfo)).EndInit();
            this.tabService.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabServiceInfo;
        private System.Windows.Forms.TabPage tabService;
        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.DataGridView dgvServicesInfo;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btnReach;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox tbService;
        private System.Windows.Forms.Label lbService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSend100;
    }
}