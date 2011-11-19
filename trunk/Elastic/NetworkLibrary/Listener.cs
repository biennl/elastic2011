using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetworkLibrary {
  
    
    class Listener : IListener{

    public TcpListener tcpListener{ get; set; }
    public string adress { get; set; }
    public int port { get; set; }

    public Listener( string adress, int port ) 
    {
        this.adress = adress;
        this.port=port;
        this.tcpListener = new TcpListener( IPAddress.Parse( adress ), port );
        this.tcpListener.Start();
    }

    /// <summary>
    /// Accepts a connexion from a client
    /// </summary>
    /// <returns></returns>
     public ISenderReceiver accept() {
      return (ISenderReceiver)(new SenderReceiver( this.tcpListener.AcceptSocket() ));
    }

    public bool pending (){
      return this.tcpListener.Pending();
    }

    public void close()
    {
        tcpListener.Stop();
    }

  }
}
