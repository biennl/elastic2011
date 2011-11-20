namespace ClientExample {
  partial class EchoServerForm {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose( bool disposing ) {
      if ( disposing && (components != null) ) {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent() {
        this.components = new System.ComponentModel.Container();
        this.btnRegister = new System.Windows.Forms.Button();
        this.lbListenPort = new System.Windows.Forms.Label();
        this.tbPortEcoute = new System.Windows.Forms.TextBox();
        this.timer = new System.Windows.Forms.Timer(this.components);
        this.groupBox = new System.Windows.Forms.GroupBox();
        this.btnStart = new System.Windows.Forms.Button();
        this.lbServiceError = new System.Windows.Forms.Label();
        this.gbRegister = new System.Windows.Forms.GroupBox();
        this.lbRegError = new System.Windows.Forms.Label();
        this.rtbLog = new System.Windows.Forms.RichTextBox();
        this.groupBox.SuspendLayout();
        this.gbRegister.SuspendLayout();
        this.SuspendLayout();
        // 
        // btnRegister
        // 
        this.btnRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.btnRegister.Location = new System.Drawing.Point(37, 40);
        this.btnRegister.Name = "btnRegister";
        this.btnRegister.Size = new System.Drawing.Size(110, 43);
        this.btnRegister.TabIndex = 2;
        this.btnRegister.Text = "Register";
        this.btnRegister.UseVisualStyleBackColor = true;
        this.btnRegister.Click += new System.EventHandler(this.registerButton_Click);
        // 
        // lbListenPort
        // 
        this.lbListenPort.AutoSize = true;
        this.lbListenPort.Location = new System.Drawing.Point(6, 31);
        this.lbListenPort.Name = "lbListenPort";
        this.lbListenPort.Size = new System.Drawing.Size(56, 13);
        this.lbListenPort.TabIndex = 9;
        this.lbListenPort.Text = "Listen port";
        // 
        // tbPortEcoute
        // 
        this.tbPortEcoute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.tbPortEcoute.Location = new System.Drawing.Point(77, 28);
        this.tbPortEcoute.Name = "tbPortEcoute";
        this.tbPortEcoute.Size = new System.Drawing.Size(110, 20);
        this.tbPortEcoute.TabIndex = 10;
        this.tbPortEcoute.Text = "50001";
        // 
        // timer
        // 
        this.timer.Enabled = true;
        this.timer.Tick += new System.EventHandler(this.timer_Tick);
        // 
        // groupBox
        // 
        this.groupBox.Controls.Add(this.btnStart);
        this.groupBox.Controls.Add(this.lbServiceError);
        this.groupBox.Controls.Add(this.lbListenPort);
        this.groupBox.Controls.Add(this.tbPortEcoute);
        this.groupBox.Location = new System.Drawing.Point(12, 5);
        this.groupBox.Name = "groupBox";
        this.groupBox.Size = new System.Drawing.Size(216, 122);
        this.groupBox.TabIndex = 12;
        this.groupBox.TabStop = false;
        this.groupBox.Text = "Starting Server";
        // 
        // btnStart
        // 
        this.btnStart.Location = new System.Drawing.Point(77, 57);
        this.btnStart.Name = "btnStart";
        this.btnStart.Size = new System.Drawing.Size(110, 43);
        this.btnStart.TabIndex = 13;
        this.btnStart.Text = "Start";
        this.btnStart.UseVisualStyleBackColor = true;
        this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
        // 
        // lbServiceError
        // 
        this.lbServiceError.AutoSize = true;
        this.lbServiceError.Location = new System.Drawing.Point(6, 100);
        this.lbServiceError.Name = "lbServiceError";
        this.lbServiceError.Size = new System.Drawing.Size(0, 13);
        this.lbServiceError.TabIndex = 12;
        // 
        // gbRegister
        // 
        this.gbRegister.Controls.Add(this.lbRegError);
        this.gbRegister.Controls.Add(this.btnRegister);
        this.gbRegister.Location = new System.Drawing.Point(251, 5);
        this.gbRegister.Name = "gbRegister";
        this.gbRegister.Size = new System.Drawing.Size(179, 122);
        this.gbRegister.TabIndex = 13;
        this.gbRegister.TabStop = false;
        this.gbRegister.Text = "Registering Service to Catalog";
        // 
        // lbRegError
        // 
        this.lbRegError.AutoSize = true;
        this.lbRegError.Location = new System.Drawing.Point(16, 100);
        this.lbRegError.Name = "lbRegError";
        this.lbRegError.Size = new System.Drawing.Size(0, 13);
        this.lbRegError.TabIndex = 12;
        // 
        // rtbLog
        // 
        this.rtbLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.rtbLog.Location = new System.Drawing.Point(12, 173);
        this.rtbLog.Name = "rtbLog";
        this.rtbLog.ReadOnly = true;
        this.rtbLog.Size = new System.Drawing.Size(418, 181);
        this.rtbLog.TabIndex = 14;
        this.rtbLog.Text = "";
        // 
        // EchoServerForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(442, 378);
        this.Controls.Add(this.rtbLog);
        this.Controls.Add(this.gbRegister);
        this.Controls.Add(this.groupBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "EchoServerForm";
        this.Text = "EchoServer";
        this.groupBox.ResumeLayout(false);
        this.groupBox.PerformLayout();
        this.gbRegister.ResumeLayout(false);
        this.gbRegister.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnRegister;
    private System.Windows.Forms.Label lbListenPort;
    private System.Windows.Forms.TextBox tbPortEcoute;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.GroupBox groupBox;
    private System.Windows.Forms.Label lbServiceError;
    private System.Windows.Forms.GroupBox gbRegister;
    private System.Windows.Forms.Label lbRegError;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.RichTextBox rtbLog;
  }
}

