using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HTTPServer
{
    class ChatServer
    {
        private List<string> _userNames = new List<string>();
        private List<ChatRoom> _chatRooms = new List<ChatRoom>();
        public void ExecuteServer()
        {
            int localPort = 1111;

            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHost.AddressList[2];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, localPort);

            Console.WriteLine("Server IP-Address is: {0} : {1}", ipAddress, localPort);

            Socket listenerSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listenerSocket.Bind(localEndPoint);

                listenerSocket.Listen(10);

                bool running = true;
                while (running)
                {
                    Console.WriteLine("Waiting on connection...");

                    Socket clientSocket = listenerSocket.Accept();

                    string sentUserName = ReceiveUserName(clientSocket);
                    string userName = VerifyUserName(sentUserName);

                    Console.WriteLine("Connected: {0}", clientSocket.RemoteEndPoint);

                    Listener newListener = new Listener(clientSocket, userName);
                    Sender newSender = new Sender(clientSocket);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string VerifyUserName(string userName)
        {
            if (_userNames.Contains(userName))
            {
                userName = userName + _userNames.FindAll(s => string.Equals(s, userName)).Count;
            }

            _userNames.Add(userName);

            return userName;
        }

        private string ReceiveUserName(Socket clientSocket)
        {
            byte[] receivedMessage = new byte[1024];
            string messageString = null;

            bool listening = true;

            while (listening)
            {
                int numByte = clientSocket.Receive(receivedMessage);

                messageString += Encoding.ASCII.GetString(receivedMessage, 0, numByte);

                if (messageString.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                {
                    listening = false;
                }
            }

            messageString = messageString.Substring(0, messageString.Length - 5);
            return messageString;
        }
    }
}
