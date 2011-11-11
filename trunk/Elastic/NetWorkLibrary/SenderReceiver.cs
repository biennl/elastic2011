using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetworkLibrary {
  /// <summary>
  /// The object SenderReceiver is used for sending and receiving datas from the network
  /// </summary>
  class SenderReceiver {

    private Socket senderReceiver;

    public SenderReceiver( Socket socket ) {
      this.senderReceiver = socket;
    }

    public SenderReceiver( string host, int port ) {
      this.senderReceiver = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
      IPAddress[] address = Dns.GetHostAddresses( host );
      senderReceiver.Connect( address, port );
    }

    /// <summary>
    /// Sending datas specified by the parameter <paramref name="bytes" />
    /// </summary>
    /// <param name="bytes"></param>
    public void send( byte[] bytes ) {
      if ( this.senderReceiver == null ) {
        throw new SystemException( "La socket a été fermée" );
      }
      int offset = 0;
      while ( offset < bytes.Length ) {
        int sent = this.senderReceiver.Send( bytes, offset, bytes.Length - offset, SocketFlags.None );
        offset += sent;
      }
    }

    /// <summary>
    /// Receive all data containing in the socket
    /// </summary>
    /// <returns></returns>
    public byte[] receive() {
      if ( this.senderReceiver == null ) {
        throw new SystemException( "La socket a été fermée" );
      }
      byte[] bytes = new byte[ this.senderReceiver.Available ];
      int offset = 0;
      while ( offset < this.senderReceiver.Available ) {
        int received = senderReceiver.Receive( bytes, offset, this.senderReceiver.Available - offset, SocketFlags.None );
        if ( received == 0 ) throw new SystemException( "Socket déconnectée" );
        offset += received;
      }
      return bytes;
    }

    /// <summary>
    /// Receive datas specified by the parameter <paramref name="count" />
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public byte[] receive( int count ) {
      if ( this.senderReceiver == null ) {
        throw new SystemException( "La socket a été fermée" );
      }
      byte[] bytes = new byte[ count ];
      int offset = 0;
      while ( offset < count ) {
        int received = senderReceiver.Receive( bytes, offset, count - offset, SocketFlags.None );
        if ( received == 0 ) throw new SystemException( "Socket déconnectée" );
        offset += received;
      }
      return bytes;
    }

    /// <summary>
    /// Closes the connexion
    /// </summary>
    public void close() {
      if ( this.senderReceiver == null ) {
        throw new SystemException( "La socket a déjà été fermée" );
      }
      this.senderReceiver.Shutdown( SocketShutdown.Both );
      this.senderReceiver.Close();
    }

  }
}
