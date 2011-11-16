namespace ClientExample {
  partial class echoServer {
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
        this.portLabel = new System.Windows.Forms.Label();
        this.portBox = new System.Windows.Forms.TextBox();
        this.registerButton = new System.Windows.Forms.Button();
        this.MessageLabel = new System.Windows.Forms.Label();
        this.MessageReceivedLabel = new System.Windows.Forms.Label();
        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        this.btdeconnexion = new System.Windows.Forms.Button();
        this.PortEcouteLabel = new System.Windows.Forms.Label();
        this.portEcouteTextBox = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // portLabel
        // 
        this.portLabel.AutoSize = true;
        this.portLabel.Location = new System.Drawing.Point(12, 15);
        this.portLabel.Name = "portLabel";
        this.portLabel.Size = new System.Drawing.Size(122, 13);
        this.portLabel.TabIndex = 0;
        this.portLabel.Text = "Port du service catalog :";
        // 
        // portBox
        // 
        this.portBox.Location = new System.Drawing.Point(140, 10);
        this.portBox.Name = "portBox";
        this.portBox.Size = new System.Drawing.Size(87, 20);
        this.portBox.TabIndex = 1;
        // 
        // registerButton
        // 
        this.registerButton.Location = new System.Drawing.Point(238, 10);
        this.registerButton.Name = "registerButton";
        this.registerButton.Size = new System.Drawing.Size(75, 23);
        this.registerButton.TabIndex = 2;
        this.registerButton.Text = "Register";
        this.registerButton.UseVisualStyleBackColor = true;
        this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
        // 
        // MessageLabel
        // 
        this.MessageLabel.AutoSize = true;
        this.MessageLabel.Location = new System.Drawing.Point(20, 108);
        this.MessageLabel.Name = "MessageLabel";
        this.MessageLabel.Size = new System.Drawing.Size(85, 13);
        this.MessageLabel.TabIndex = 6;
        this.MessageLabel.Text = "Message Reçu :";
        // 
        // MessageReceivedLabel
        // 
        this.MessageReceivedLabel.AutoSize = true;
        this.MessageReceivedLabel.Location = new System.Drawing.Point(120, 108);
        this.MessageReceivedLabel.Name = "MessageReceivedLabel";
        this.MessageReceivedLabel.Size = new System.Drawing.Size(10, 13);
        this.MessageReceivedLabel.TabIndex = 7;
        this.MessageReceivedLabel.Text = "-";
        // 
        // backgroundWorker1
        // 
        this.backgroundWorker1.WorkerSupportsCancellation = true;
        this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
        // 
        // btdeconnexion
        // 
        this.btdeconnexion.Enabled = false;
        this.btdeconnexion.Location = new System.Drawing.Point(304, 53);
        this.btdeconnexion.Name = "btdeconnexion";
        this.btdeconnexion.Size = new System.Drawing.Size(82, 23);
        this.btdeconnexion.TabIndex = 8;
        this.btdeconnexion.Text = "deconnexion";
        this.btdeconnexion.UseVisualStyleBackColor = true;
        this.btdeconnexion.Click += new System.EventHandler(this.btdeconnexion_Click);
        // 
        // PortEcouteLabel
        // 
        this.PortEcouteLabel.AutoSize = true;
        this.PortEcouteLabel.Location = new System.Drawing.Point(20, 59);
        this.PortEcouteLabel.Name = "PortEcouteLabel";
        this.PortEcouteLabel.Size = new System.Drawing.Size(76, 13);
        this.PortEcouteLabel.TabIndex = 9;
        this.PortEcouteLabel.Text = "Port d\'écoute :";
        // 
        // portEcouteTextBox
        // 
        this.portEcouteTextBox.Location = new System.Drawing.Point(102, 56);
        this.portEcouteTextBox.Name = "portEcouteTextBox";
        this.portEcouteTextBox.Size = new System.Drawing.Size(100, 20);
        this.portEcouteTextBox.TabIndex = 10;
        // 
        // echoServer
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(587, 262);
        this.Controls.Add(this.portEcouteTextBox);
        this.Controls.Add(this.PortEcouteLabel);
        this.Controls.Add(this.btdeconnexion);
        this.Controls.Add(this.MessageReceivedLabel);
        this.Controls.Add(this.MessageLabel);
        this.Controls.Add(this.registerButton);
        this.Controls.Add(this.portBox);
        this.Controls.Add(this.portLabel);
        this.Name = "echoServer";
        this.Text = "EchoServer";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label portLabel;
    private System.Windows.Forms.TextBox portBox;
    private System.Windows.Forms.Button registerButton;
    private System.Windows.Forms.Label MessageLabel;
    private System.Windows.Forms.Label MessageReceivedLabel;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Button btdeconnexion;
    private System.Windows.Forms.Label PortEcouteLabel;
    private System.Windows.Forms.TextBox portEcouteTextBox;
  }
}

