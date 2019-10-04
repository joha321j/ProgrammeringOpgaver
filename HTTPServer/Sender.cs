using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTPServer
{
    class Sender
    {
        private readonly Socket _socket;

        public Sender(Socket socket)
        {
            _socket = socket;
            Program.MessageReceivedEventHandler += Send;
        }
        private void Send(object o = null, EventArgs e = null)
        {
            byte[] bytesToSend = Encoding.UTF8.GetBytes(o.ToString());

            _socket.Send(bytesToSend);
        }
    }
}
