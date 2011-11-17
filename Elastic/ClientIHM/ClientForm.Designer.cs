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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabServiceInfo = new System.Windows.Forms.TabPage();
            this.btnRequest = new System.Windows.Forms.Button();
            this.tbService = new System.Windows.Forms.TextBox();
            this.lbService = new System.Windows.Forms.Label();
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
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabServiceInfo.SuspendLayout();
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
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.disconnectToolStripMenuItem.Text = "&Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabServiceInfo);
            this.tabControl.Controls.Add(this.tabService);
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(419, 366);
            this.tabControl.TabIndex = 1;
            // 
            // tabServiceInfo
            // 
            this.tabServiceInfo.Controls.Add(this.btnRequest);
            this.tabServiceInfo.Controls.Add(this.tbService);
            this.tabServiceInfo.Controls.Add(this.lbService);
            this.tabServiceInfo.Controls.Add(this.lbInfo);
            this.tabServiceInfo.Controls.Add(this.btnReach);
            this.tabServiceInfo.Controls.Add(this.dgvServicesInfo);
            this.tabServiceInfo.Location = new System.Drawing.Point(4, 22);
            this.tabServiceInfo.Name = "tabServiceInfo";
            this.tabServiceInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabServiceInfo.Size = new System.Drawing.Size(411, 340);
            this.tabServiceInfo.TabIndex = 0;
            this.tabServiceInfo.Text = "Services Information";
            this.tabServiceInfo.UseVisualStyleBackColor = true;
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(298, 253);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 5;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // tbService
            // 
            this.tbService.Location = new System.Drawing.Point(113, 255);
            this.tbService.Name = "tbService";
            this.tbService.Size = new System.Drawing.Size(125, 20);
            this.tbService.TabIndex = 4;
            // 
            // lbService
            // 
            this.lbService.AutoSize = true;
            this.lbService.Location = new System.Drawing.Point(9, 255);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(74, 13);
            this.lbService.TabIndex = 3;
            this.lbService.Text = "Service Name";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(132, 307);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(149, 13);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "Select one sercie to connect..";
            // 
            // btnReach
            // 
            this.btnReach.Location = new System.Drawing.Point(8, 295);
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
            this.dgvServicesInfo.Location = new System.Drawing.Point(8, 6);
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
            this.tabService.Controls.Add(this.btnSend);
            this.tabService.Controls.Add(this.rtbInput);
            this.tabService.Controls.Add(this.rtbDisplay);
            this.tabService.Location = new System.Drawing.Point(4, 22);
            this.tabService.Name = "tabService";
            this.tabService.Padding = new System.Windows.Forms.Padding(3);
            this.tabService.Size = new System.Drawing.Size(411, 340);
            this.tabService.TabIndex = 1;
            this.tabService.Text = "Service";
            this.tabService.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(292, 271);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 60);
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
            this.rtbInput.Text = "";
            this.rtbInput.TextChanged += new System.EventHandler(this.rtbInput_TextChanged);
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Location = new System.Drawing.Point(9, 7);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.Size = new System.Drawing.Size(276, 207);
            this.rtbDisplay.TabIndex = 0;
            this.rtbDisplay.Text = "";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 394);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabServiceInfo.ResumeLayout(false);
            this.tabServiceInfo.PerformLayout();
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
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.DataGridView dgvServicesInfo;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btnReach;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox tbService;
        private System.Windows.Forms.Label lbService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
    }
}