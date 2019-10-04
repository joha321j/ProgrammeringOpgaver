using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTPServer
{
    class Listener
    {
        private readonly Socket _socket;
        private string _userName;

        public Listener(Socket socket, string userName)
        {
            _socket = socket;
            _userName = userName;

            Thread listeningThread = new Thread(Listen);
        }

        public void Listen()
        {
            byte[] receivedMessage = new byte[1024];
            string data = null;

            bool listening = true;

            while (listening)
            {
                int numByte = _socket.Receive(receivedMessage);

                data += Encoding.UTF8.GetString(receivedMessage, 0, numByte);

                if (data.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                {
                    listening = false;
                }
            }

            Console.WriteLine(_userName + ": " + receivedMessage);

            Program.MessageReceivedEventHandler.Invoke(_userName + ";" + receivedMessage, EventArgs.Empty);
        }
    }
}
