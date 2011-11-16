namespace ServerExample {
  partial class Server {
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
        this.portBox = new System.Windows.Forms.TextBox();
        this.PortLabel = new System.Windows.Forms.Label();
        this.connexionButton = new System.Windows.Forms.Button();
        this.messageLabel = new System.Windows.Forms.Label();
        this.messageReceivedLabel = new System.Windows.Forms.Label();
        this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        this.registeredServices = new System.Windows.Forms.RichTextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.button1 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // portBox
        // 
        this.portBox.Location = new System.Drawing.Point(50, 16);
        this.portBox.Name = "portBox";
        this.portBox.Size = new System.Drawing.Size(89, 20);
        this.portBox.TabIndex = 0;
        this.portBox.TextChanged += new System.EventHandler(this.portBox_TextChanged);
        // 
        // PortLabel
        // 
        this.PortLabel.AutoSize = true;
        this.PortLabel.Location = new System.Drawing.Point(12, 19);
        this.PortLabel.Name = "PortLabel";
        this.PortLabel.Size = new System.Drawing.Size(32, 13);
        this.PortLabel.TabIndex = 1;
        this.PortLabel.Text = "Port :";
        // 
        // connexionButton
        // 
        this.connexionButton.Location = new System.Drawing.Point(145, 14);
        this.connexionButton.Name = "connexionButton";
        this.connexionButton.Size = new System.Drawing.Size(75, 23);
        this.connexionButton.TabIndex = 2;
        this.connexionButton.Text = "Connexion";
        this.connexionButton.UseVisualStyleBackColor = true;
        this.connexionButton.Click += new System.EventHandler(this.connexionButton_Click);
        // 
        // messageLabel
        // 
        this.messageLabel.AutoSize = true;
        this.messageLabel.Location = new System.Drawing.Point(12, 62);
        this.messageLabel.Name = "messageLabel";
        this.messageLabel.Size = new System.Drawing.Size(80, 13);
        this.messageLabel.TabIndex = 3;
        this.messageLabel.Text = "Message reçu :";
        // 
        // messageReceivedLabel
        // 
        this.messageReceivedLabel.AutoSize = true;
        this.messageReceivedLabel.Location = new System.Drawing.Point(98, 62);
        this.messageReceivedLabel.Name = "messageReceivedLabel";
        this.messageReceivedLabel.Size = new System.Drawing.Size(10, 13);
        this.messageReceivedLabel.TabIndex = 4;
        this.messageReceivedLabel.Text = "-";
        // 
        // backgroundWorker1
        // 
        this.backgroundWorker1.WorkerSupportsCancellation = true;
        this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
        // 
        // registeredServices
        // 
        this.registeredServices.Location = new System.Drawing.Point(12, 130);
        this.registeredServices.Name = "registeredServices";
        this.registeredServices.Size = new System.Drawing.Size(270, 96);
        this.registeredServices.TabIndex = 5;
        this.registeredServices.Text = "";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(25, 114);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(139, 13);
        this.label1.TabIndex = 6;
        this.label1.Text = "List des services enregistrés";
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(170, 101);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(102, 23);
        this.button1.TabIndex = 7;
        this.button1.Text = "Display Services";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // Server
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 262);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.registeredServices);
        this.Controls.Add(this.messageReceivedLabel);
        this.Controls.Add(this.messageLabel);
        this.Controls.Add(this.connexionButton);
        this.Controls.Add(this.PortLabel);
        this.Controls.Add(this.portBox);
        this.Name = "Server";
        this.Text = "ServerCatalog";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox portBox;
    private System.Windows.Forms.Label PortLabel;
    private System.Windows.Forms.Button connexionButton;
    private System.Windows.Forms.Label messageLabel;
    private System.Windows.Forms.Label messageReceivedLabel;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.RichTextBox registeredServices;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;

  }
}

