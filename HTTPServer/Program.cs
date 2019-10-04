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
            ChatServer chatServer = new ChatServer();
            Thread serverThread = new Thread(chatServer.ExecuteServer);
            serverThread.Start();
        }

    }
}
