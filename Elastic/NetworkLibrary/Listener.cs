using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetworkLibrary {
  public class Listener {

    private TcpListener tcpListener;

    public Listener( String adress, int port ) {
      this.tcpListener = new TcpListener( IPAddress.Parse( adress ), port );
      this.tcpListener.Start();
    }

    /// <summary>
    /// Accepts a connexion from a client
    /// </summary>
    /// <returns></returns>
    public SenderReceiver accept() {
      return new SenderReceiver( this.tcpListener.AcceptSocket() );
    }

  }
}
