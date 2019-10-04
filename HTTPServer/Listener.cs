using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Runtime.InteropServices.ComTypes;
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
            listeningThread.Start();
        }

        public void Listen()
        {
            bool running = true;
            while (running)
            {
                byte[] receivedMessage = new byte[1024];
                string messageString = null;

                bool listening = true;

                while (listening)
                {
                    int numByte = _socket.Receive(receivedMessage);

                    messageString += Encoding.ASCII.GetString(receivedMessage, 0, numByte);

                    if (messageString.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                    {
                        listening = false;
                    }
                }

                Console.WriteLine(_userName + ": " + messageString);

                Program.MessageReceivedEventHandler.Invoke(_userName + ": " + messageString, EventArgs.Empty);
            }
        }
    }
}
