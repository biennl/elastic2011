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
        this.portLabel = new System.Windows.Forms.Label();
        this.tbPortBox = new System.Windows.Forms.TextBox();
        this.btnRegister = new System.Windows.Forms.Button();
        this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
        this.btnDeconnexion = new System.Windows.Forms.Button();
        this.PortEcouteLabel = new System.Windows.Forms.Label();
        this.tbPortEcoute = new System.Windows.Forms.TextBox();
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
        // tbPortBox
        // 
        this.tbPortBox.Location = new System.Drawing.Point(140, 10);
        this.tbPortBox.Name = "tbPortBox";
        this.tbPortBox.Size = new System.Drawing.Size(100, 20);
        this.tbPortBox.TabIndex = 1;
        // 
        // btnRegister
        // 
        this.btnRegister.Location = new System.Drawing.Point(188, 162);
        this.btnRegister.Name = "btnRegister";
        this.btnRegister.Size = new System.Drawing.Size(82, 23);
        this.btnRegister.TabIndex = 2;
        this.btnRegister.Text = "Register";
        this.btnRegister.UseVisualStyleBackColor = true;
        this.btnRegister.Click += new System.EventHandler(this.registerButton_Click);
        // 
        // backgroundWorker
        // 
        this.backgroundWorker.WorkerSupportsCancellation = true;
        this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
        // 
        // btnDeconnexion
        // 
        this.btnDeconnexion.Enabled = false;
        this.btnDeconnexion.Location = new System.Drawing.Point(188, 191);
        this.btnDeconnexion.Name = "btnDeconnexion";
        this.btnDeconnexion.Size = new System.Drawing.Size(82, 23);
        this.btnDeconnexion.TabIndex = 8;
        this.btnDeconnexion.Text = "Deconnexion";
        this.btnDeconnexion.UseVisualStyleBackColor = true;
        this.btnDeconnexion.Click += new System.EventHandler(this.btdeconnexion_Click);
        // 
        // PortEcouteLabel
        // 
        this.PortEcouteLabel.AutoSize = true;
        this.PortEcouteLabel.Location = new System.Drawing.Point(12, 59);
        this.PortEcouteLabel.Name = "PortEcouteLabel";
        this.PortEcouteLabel.Size = new System.Drawing.Size(76, 13);
        this.PortEcouteLabel.TabIndex = 9;
        this.PortEcouteLabel.Text = "Port d\'écoute :";
        // 
        // tbPortEcoute
        // 
        this.tbPortEcoute.Location = new System.Drawing.Point(140, 55);
        this.tbPortEcoute.Name = "tbPortEcoute";
        this.tbPortEcoute.Size = new System.Drawing.Size(100, 20);
        this.tbPortEcoute.TabIndex = 10;
        // 
        // EchoServerForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(282, 226);
        this.Controls.Add(this.tbPortEcoute);
        this.Controls.Add(this.PortEcouteLabel);
        this.Controls.Add(this.btnDeconnexion);
        this.Controls.Add(this.btnRegister);
        this.Controls.Add(this.tbPortBox);
        this.Controls.Add(this.portLabel);
        this.Name = "EchoServerForm";
        this.Text = "EchoServer";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label portLabel;
    private System.Windows.Forms.TextBox tbPortBox;
    private System.Windows.Forms.Button btnRegister;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Windows.Forms.Button btnDeconnexion;
    private System.Windows.Forms.Label PortEcouteLabel;
    private System.Windows.Forms.TextBox tbPortEcoute;
  }
}

