using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTTPServer
{
    class Program
    {
        public static EventHandler MessageReceivedEventHandler;
        static void Main(string[] args)
        {
            ExecuteServer();
        }

        private static void ExecuteServer()
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

                    Console.WriteLine("Connected: {0}", clientSocket.RemoteEndPoint);

                    Listener newListener = new Listener(clientSocket, "FISSE");
                    Sender newSender = new Sender(clientSocket);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
