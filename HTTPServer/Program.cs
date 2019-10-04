using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HTTPServer
{
    class Program
    {
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



                    byte[] bytes = new byte[1024];
                    string data = null;

                    bool receivingData = true;

                    while (receivingData)
                    {
                        int numByte = clientSocket.Receive(bytes);

                        data += Encoding.ASCII.GetString(bytes, 0, numByte);

                        if (data.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                        {
                            receivingData = false;
                        }
                    }

                    Console.WriteLine("Text received -> {0}", data);
                    byte[] message = Encoding.ASCII.GetBytes("Test server response");

                    clientSocket.Send(message);

                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();

                    Console.WriteLine("Press 0 to shutdown server.");

                    bool validInput = false;
                    int userInput = 5;
                    while (!validInput)
                    {
                        validInput = int.TryParse(Console.ReadLine(), out userInput);
                    }

                    if (userInput == 0)
                    {
                        running = false;
                    }

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
