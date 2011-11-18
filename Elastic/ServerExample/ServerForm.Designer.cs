namespace ServerExample {
  partial class ServerForm {
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
        this.tbPort = new System.Windows.Forms.TextBox();
        this.lbPort = new System.Windows.Forms.Label();
        this.btnStart = new System.Windows.Forms.Button();
        this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
        this.tbRegisteredServices = new System.Windows.Forms.RichTextBox();
        this.labelServicesList = new System.Windows.Forms.Label();
        this.btnDisplay = new System.Windows.Forms.Button();
        this.lbConfig = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // tbPort
        // 
        this.tbPort.Location = new System.Drawing.Point(50, 16);
        this.tbPort.Name = "tbPort";
        this.tbPort.Size = new System.Drawing.Size(89, 20);
        this.tbPort.TabIndex = 0;
        // 
        // lbPort
        // 
        this.lbPort.AutoSize = true;
        this.lbPort.Location = new System.Drawing.Point(12, 19);
        this.lbPort.Name = "lbPort";
        this.lbPort.Size = new System.Drawing.Size(32, 13);
        this.lbPort.TabIndex = 1;
        this.lbPort.Text = "Port :";
        // 
        // btnStart
        // 
        this.btnStart.Location = new System.Drawing.Point(170, 14);
        this.btnStart.Name = "btnStart";
        this.btnStart.Size = new System.Drawing.Size(102, 23);
        this.btnStart.TabIndex = 2;
        this.btnStart.Text = "Start";
        this.btnStart.UseVisualStyleBackColor = true;
        this.btnStart.Click += new System.EventHandler(this.connexionButton_Click);
        // 
        // backgroundWorker
        // 
        this.backgroundWorker.WorkerSupportsCancellation = true;
        this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
        // 
        // tbRegisteredServices
        // 
        this.tbRegisteredServices.Location = new System.Drawing.Point(2, 98);
        this.tbRegisteredServices.Name = "tbRegisteredServices";
        this.tbRegisteredServices.Size = new System.Drawing.Size(277, 96);
        this.tbRegisteredServices.TabIndex = 5;
        this.tbRegisteredServices.Text = "";
        // 
        // labelServicesList
        // 
        this.labelServicesList.AutoSize = true;
        this.labelServicesList.Location = new System.Drawing.Point(12, 69);
        this.labelServicesList.Name = "labelServicesList";
        this.labelServicesList.Size = new System.Drawing.Size(139, 13);
        this.labelServicesList.TabIndex = 6;
        this.labelServicesList.Text = "List des services enregistrés";
        // 
        // btnDisplay
        // 
        this.btnDisplay.Location = new System.Drawing.Point(170, 69);
        this.btnDisplay.Name = "btnDisplay";
        this.btnDisplay.Size = new System.Drawing.Size(102, 23);
        this.btnDisplay.TabIndex = 7;
        this.btnDisplay.Text = "Display Services";
        this.btnDisplay.UseVisualStyleBackColor = true;
        this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
        // 
        // lbConfig
        // 
        this.lbConfig.AutoSize = true;
        this.lbConfig.Location = new System.Drawing.Point(15, 221);
        this.lbConfig.Name = "lbConfig";
        this.lbConfig.Size = new System.Drawing.Size(99, 13);
        this.lbConfig.TabIndex = 8;
        this.lbConfig.Text = "CONFIGURATION:";
        // 
        // ServerForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 262);
        this.Controls.Add(this.lbConfig);
        this.Controls.Add(this.btnDisplay);
        this.Controls.Add(this.labelServicesList);
        this.Controls.Add(this.tbRegisteredServices);
        this.Controls.Add(this.btnStart);
        this.Controls.Add(this.lbPort);
        this.Controls.Add(this.tbPort);
        this.Name = "ServerForm";
        this.Text = "Catalog Server";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbPort;
    private System.Windows.Forms.Label lbPort;
    private System.Windows.Forms.Button btnStart;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Windows.Forms.RichTextBox tbRegisteredServices;
    private System.Windows.Forms.Label labelServicesList;
    private System.Windows.Forms.Button btnDisplay;
    private System.Windows.Forms.Label lbConfig;

  }
}

