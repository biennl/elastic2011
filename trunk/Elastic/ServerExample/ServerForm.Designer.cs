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
        this.btnStart = new System.Windows.Forms.Button();
        this.tbRegisteredServices = new System.Windows.Forms.RichTextBox();
        this.labelServicesList = new System.Windows.Forms.Label();
        this.lbConfig = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // btnStart
        // 
        this.btnStart.Location = new System.Drawing.Point(12, 12);
        this.btnStart.Name = "btnStart";
        this.btnStart.Size = new System.Drawing.Size(102, 41);
        this.btnStart.TabIndex = 2;
        this.btnStart.Text = "Start";
        this.btnStart.UseVisualStyleBackColor = true;
        this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
        // 
        // tbRegisteredServices
        // 
        this.tbRegisteredServices.Location = new System.Drawing.Point(3, 121);
        this.tbRegisteredServices.Name = "tbRegisteredServices";
        this.tbRegisteredServices.Size = new System.Drawing.Size(277, 136);
        this.tbRegisteredServices.TabIndex = 5;
        this.tbRegisteredServices.Text = "";
        // 
        // labelServicesList
        // 
        this.labelServicesList.AutoSize = true;
        this.labelServicesList.Location = new System.Drawing.Point(0, 105);
        this.labelServicesList.Name = "labelServicesList";
        this.labelServicesList.Size = new System.Drawing.Size(94, 13);
        this.labelServicesList.TabIndex = 6;
        this.labelServicesList.Text = "Available Services";
        // 
        // lbConfig
        // 
        this.lbConfig.AutoSize = true;
        this.lbConfig.Location = new System.Drawing.Point(15, 56);
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
        this.Controls.Add(this.labelServicesList);
        this.Controls.Add(this.tbRegisteredServices);
        this.Controls.Add(this.btnStart);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MinimizeBox = false;
        this.Name = "ServerForm";
        this.Text = "Catalog Server";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.RichTextBox tbRegisteredServices;
    private System.Windows.Forms.Label labelServicesList;
    private System.Windows.Forms.Label lbConfig;

  }
}

