namespace ClientIHM
{
    partial class IHMForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.gbSubscribers = new System.Windows.Forms.GroupBox();
            this.dgvSubs = new System.Windows.Forms.DataGridView();
            this.Machine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addresss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMessage = new System.Windows.Forms.GroupBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.gbImage.SuspendLayout();
            this.gbSubscribers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubs)).BeginInit();
            this.gbMessage.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::ClientIHM.Properties.Resources.ajouter_icone_8647_961;
            this.pictureBox.Location = new System.Drawing.Point(9, 38);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(324, 304);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox, "Double click to select an image");
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(123, 507);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 52);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Broadcast";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(258, 9);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 0;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // gbImage
            // 
            this.gbImage.Controls.Add(this.pictureBox);
            this.gbImage.Controls.Add(this.btnBrowser);
            this.gbImage.Location = new System.Drawing.Point(12, 12);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(339, 352);
            this.gbImage.TabIndex = 0;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Imaging";
            // 
            // gbSubscribers
            // 
            this.gbSubscribers.Controls.Add(this.dgvSubs);
            this.gbSubscribers.Location = new System.Drawing.Point(357, 12);
            this.gbSubscribers.Name = "gbSubscribers";
            this.gbSubscribers.Size = new System.Drawing.Size(369, 352);
            this.gbSubscribers.TabIndex = 4;
            this.gbSubscribers.TabStop = false;
            this.gbSubscribers.Text = "Subscribers";
            // 
            // dgvSubs
            // 
            this.dgvSubs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Machine,
            this.Addresss,
            this.PortNumber});
            this.dgvSubs.Location = new System.Drawing.Point(6, 38);
            this.dgvSubs.Name = "dgvSubs";
            this.dgvSubs.Size = new System.Drawing.Size(357, 304);
            this.dgvSubs.TabIndex = 0;
            this.toolTip.SetToolTip(this.dgvSubs, "List of subscribers.\r\nYou can select one or more for broadcasting messages to.");
            // 
            // Machine
            // 
            this.Machine.HeaderText = "Machine";
            this.Machine.Name = "Machine";
            this.Machine.ReadOnly = true;
            this.Machine.Width = 103;
            // 
            // Addresss
            // 
            this.Addresss.HeaderText = "Address";
            this.Addresss.Name = "Addresss";
            this.Addresss.ReadOnly = true;
            this.Addresss.Width = 140;
            // 
            // PortNumber
            // 
            this.PortNumber.HeaderText = "Port";
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.ReadOnly = true;
            this.PortNumber.Width = 70;
            // 
            // gbMessage
            // 
            this.gbMessage.Controls.Add(this.tbMessage);
            this.gbMessage.Location = new System.Drawing.Point(12, 370);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Size = new System.Drawing.Size(339, 113);
            this.gbMessage.TabIndex = 1;
            this.gbMessage.TabStop = false;
            this.gbMessage.Text = "Messaging";
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(6, 20);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMessage.Size = new System.Drawing.Size(324, 87);
            this.tbMessage.TabIndex = 0;
            this.toolTip.SetToolTip(this.tbMessage, "Enter text message");
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.tbLog);
            this.gbLog.Location = new System.Drawing.Point(358, 370);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(368, 238);
            this.gbLog.TabIndex = 6;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Logging";
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.White;
            this.tbLog.Location = new System.Drawing.Point(6, 19);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(356, 213);
            this.tbLog.TabIndex = 1;
            this.toolTip.SetToolTip(this.tbLog, "Server log");
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 620);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbMessage);
            this.Controls.Add(this.gbSubscribers);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.Text = "Poste central";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.gbImage.ResumeLayout(false);
            this.gbSubscribers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubs)).EndInit();
            this.gbMessage.ResumeLayout(false);
            this.gbMessage.PerformLayout();
            this.gbLog.ResumeLayout(false);
            this.gbLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.GroupBox gbSubscribers;
        private System.Windows.Forms.DataGridView dgvSubs;
        private System.Windows.Forms.GroupBox gbMessage;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Machine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addresss;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortNumber;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.ToolTip toolTip;
    }
}