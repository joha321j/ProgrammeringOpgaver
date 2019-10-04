using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTTPClient
{
    class Controller
    {

        public EventHandler ResponseEventHandler;
        private readonly Socket _socket;

        public Controller(string address, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(address);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            _socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            _socket.Connect(localEndPoint);

            Thread listeningThread = new Thread(ListenToServer);
            listeningThread.Start();
        }
        public void SendMessage(string message)
        {
            byte[] messageSent = Encoding.ASCII.GetBytes(message + "<EOF>");
            int byteSent = _socket.Send(messageSent);
        }

        public void ListenToServer()
        {
            bool running = true;
            while (running)
            {
                byte[] messageReceived = new byte[1024];

                int byteReceived = _socket.Receive(messageReceived);

                ResponseEventHandler?.Invoke(Encoding.ASCII.GetString(messageReceived,
                        0,
                        byteReceived),
                    EventArgs.Empty);
            }
        }
    }
}
