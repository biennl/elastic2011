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
        this.connexionButton = new System.Windows.Forms.Button();
        this.MessageLabel = new System.Windows.Forms.Label();
        this.MessageReceivedLabel = new System.Windows.Forms.Label();
        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        this.btdeconnexion = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // portLabel
        // 
        this.portLabel.AutoSize = true;
        this.portLabel.Location = new System.Drawing.Point(20, 19);
        this.portLabel.Name = "portLabel";
        this.portLabel.Size = new System.Drawing.Size(32, 13);
        this.portLabel.TabIndex = 0;
        this.portLabel.Text = "Port :";
        // 
        // portBox
        // 
        this.portBox.Location = new System.Drawing.Point(58, 16);
        this.portBox.Name = "portBox";
        this.portBox.Size = new System.Drawing.Size(87, 20);
        this.portBox.TabIndex = 1;
        // 
        // connexionButton
        // 
        this.connexionButton.Location = new System.Drawing.Point(151, 14);
        this.connexionButton.Name = "connexionButton";
        this.connexionButton.Size = new System.Drawing.Size(75, 23);
        this.connexionButton.TabIndex = 2;
        this.connexionButton.Text = "Connexion";
        this.connexionButton.UseVisualStyleBackColor = true;
        this.connexionButton.Click += new System.EventHandler(this.connexionButton_Click);
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
        this.btdeconnexion.Location = new System.Drawing.Point(244, 13);
        this.btdeconnexion.Name = "btdeconnexion";
        this.btdeconnexion.Size = new System.Drawing.Size(82, 23);
        this.btdeconnexion.TabIndex = 8;
        this.btdeconnexion.Text = "deconnexion";
        this.btdeconnexion.UseVisualStyleBackColor = true;
        this.btdeconnexion.Click += new System.EventHandler(this.btdeconnexion_Click);
        // 
        // echoServer
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(356, 262);
        this.Controls.Add(this.btdeconnexion);
        this.Controls.Add(this.MessageReceivedLabel);
        this.Controls.Add(this.MessageLabel);
        this.Controls.Add(this.connexionButton);
        this.Controls.Add(this.portBox);
        this.Controls.Add(this.portLabel);
        this.Name = "echoServer";
        this.Text = "Form1";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label portLabel;
    private System.Windows.Forms.TextBox portBox;
    private System.Windows.Forms.Button connexionButton;
    private System.Windows.Forms.Label MessageLabel;
    private System.Windows.Forms.Label MessageReceivedLabel;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Button btdeconnexion;
  }
}

