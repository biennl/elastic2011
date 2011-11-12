using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetworkLibrary;

namespace ServerExample {
  public partial class Server : Form {

    NetworkManager networkManager;
    IListener listener;
    ISenderReceiver senderReceiver;

    public Server() {
      InitializeComponent();
      this.networkManager = new NetworkManager();
    }

    private void portBox_TextChanged( object sender, EventArgs e ) {

    }

    private void connexionButton_Click( object sender, EventArgs e ) {
      this.listener = this.networkManager.createListner("127.0.0.1", Convert.ToInt32( this.portBox.Text ));
      this.connexionButton.Enabled = false;
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void backgroundWorker1_DoWork( object sender, DoWorkEventArgs e ) {
      while ( true ) {
        if ( this.listener.pending() == true ) {
          senderReceiver = this.listener.accept();
        }

        if ( (this.senderReceiver != null) && (senderReceiver.available() != 0) ) {
          UTF8Encoding utf8Encoding = new UTF8Encoding();
          this.messageReceivedLabel.Text = utf8Encoding.GetString( senderReceiver.receive() );
          senderReceiver.send( utf8Encoding.GetBytes( this.messageReceivedLabel.Text ) );
        }
         
      }
    }
  }
}
