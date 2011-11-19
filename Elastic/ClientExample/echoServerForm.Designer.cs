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
      this.lbPortCatalog = new System.Windows.Forms.Label();
      this.tbPortBox = new System.Windows.Forms.TextBox();
      this.btnRegister = new System.Windows.Forms.Button();
      this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.btnDisconnect = new System.Windows.Forms.Button();
      this.lbListenPort = new System.Windows.Forms.Label();
      this.tbPortEcoute = new System.Windows.Forms.TextBox();
      this.btnUnregister = new System.Windows.Forms.Button();
      this.timer = new System.Windows.Forms.Timer( this.components );
      this.SuspendLayout();
      // 
      // lbPortCatalog
      // 
      this.lbPortCatalog.AutoSize = true;
      this.lbPortCatalog.Location = new System.Drawing.Point( 12, 15 );
      this.lbPortCatalog.Name = "lbPortCatalog";
      this.lbPortCatalog.Size = new System.Drawing.Size( 64, 13 );
      this.lbPortCatalog.TabIndex = 0;
      this.lbPortCatalog.Text = "Catalog port";
      // 
      // tbPortBox
      // 
      this.tbPortBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tbPortBox.Location = new System.Drawing.Point( 100, 12 );
      this.tbPortBox.Name = "tbPortBox";
      this.tbPortBox.Size = new System.Drawing.Size( 123, 20 );
      this.tbPortBox.TabIndex = 1;
      this.tbPortBox.Text = "50000";
      // 
      // btnRegister
      // 
      this.btnRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.btnRegister.Location = new System.Drawing.Point( 188, 134 );
      this.btnRegister.Name = "btnRegister";
      this.btnRegister.Size = new System.Drawing.Size( 82, 23 );
      this.btnRegister.TabIndex = 2;
      this.btnRegister.Text = "Register";
      this.btnRegister.UseVisualStyleBackColor = true;
      this.btnRegister.Click += new System.EventHandler( this.registerButton_Click );
      // 
      // backgroundWorker
      // 
      //this.backgroundWorker.WorkerSupportsCancellation = true;
      //this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.backgroundWorker_DoWork );
      // 
      // btnDisconnect
      // 
      this.btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDisconnect.AutoSize = true;
      this.btnDisconnect.Enabled = false;
      this.btnDisconnect.Location = new System.Drawing.Point( 188, 191 );
      this.btnDisconnect.Name = "btnDisconnect";
      this.btnDisconnect.Size = new System.Drawing.Size( 82, 23 );
      this.btnDisconnect.TabIndex = 8;
      this.btnDisconnect.Text = "Disconnect";
      this.btnDisconnect.UseVisualStyleBackColor = true;
      this.btnDisconnect.Click += new System.EventHandler( this.btdeconnexion_Click );
      // 
      // lbListenPort
      // 
      this.lbListenPort.AutoSize = true;
      this.lbListenPort.Location = new System.Drawing.Point( 12, 41 );
      this.lbListenPort.Name = "lbListenPort";
      this.lbListenPort.Size = new System.Drawing.Size( 56, 13 );
      this.lbListenPort.TabIndex = 9;
      this.lbListenPort.Text = "Listen port";
      // 
      // tbPortEcoute
      // 
      this.tbPortEcoute.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tbPortEcoute.Location = new System.Drawing.Point( 100, 38 );
      this.tbPortEcoute.Name = "tbPortEcoute";
      this.tbPortEcoute.Size = new System.Drawing.Size( 123, 20 );
      this.tbPortEcoute.TabIndex = 10;
      this.tbPortEcoute.Text = "50001";
      // 
      // btnUnregister
      // 
      this.btnUnregister.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnUnregister.Enabled = false;
      this.btnUnregister.Location = new System.Drawing.Point( 188, 162 );
      this.btnUnregister.Name = "btnUnregister";
      this.btnUnregister.Size = new System.Drawing.Size( 82, 23 );
      this.btnUnregister.TabIndex = 11;
      this.btnUnregister.Text = "Unregister";
      this.btnUnregister.UseVisualStyleBackColor = true;
      this.btnUnregister.Click += new System.EventHandler( this.btnUnregister_Click );
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Tick += new System.EventHandler( this.timer_Tick );
      // 
      // EchoServerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 282, 226 );
      this.Controls.Add( this.btnUnregister );
      this.Controls.Add( this.tbPortEcoute );
      this.Controls.Add( this.lbListenPort );
      this.Controls.Add( this.btnDisconnect );
      this.Controls.Add( this.btnRegister );
      this.Controls.Add( this.tbPortBox );
      this.Controls.Add( this.lbPortCatalog );
      this.Name = "EchoServerForm";
      this.Text = "EchoServer";
      this.ResumeLayout( false );
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lbPortCatalog;
    private System.Windows.Forms.TextBox tbPortBox;
    private System.Windows.Forms.Button btnRegister;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Windows.Forms.Button btnDisconnect;
    private System.Windows.Forms.Label lbListenPort;
    private System.Windows.Forms.TextBox tbPortEcoute;
    private System.Windows.Forms.Button btnUnregister;
    private System.Windows.Forms.Timer timer;
  }
}

