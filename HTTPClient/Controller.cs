using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HTTPClient
{
    class Controller
    {

        public EventHandler ResponseEventHandler;
        public void SendMessage(string address, int port, string message)
        {

            IPAddress ipAddress = IPAddress.Parse(address);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            Socket senderSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            senderSocket.Connect(localEndPoint);

            byte[] messageSent = Encoding.ASCII.GetBytes(message + "<EOF>");
            int byteSent = senderSocket.Send(messageSent);

            byte[] messageReceived = new byte[1024];

            int byteReceived = senderSocket.Receive(messageReceived);

            ResponseEventHandler?.Invoke(Encoding.ASCII.GetString(messageReceived,
                    0,
                    byteReceived),
                EventArgs.Empty);

            senderSocket.Shutdown(SocketShutdown.Both);
            senderSocket.Close();


        }
    }
}
