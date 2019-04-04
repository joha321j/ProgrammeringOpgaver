using System;
using System.IO;
using System.IO.Pipes;

namespace PipeClient
{
    public class Client
    {
        private string _message = string.Empty;

        public void Run(string pipeName)
        {
            using (NamedPipeClientStream client = new NamedPipeClientStream(pipeName))
            {
                Console.WriteLine("Forsøger at forbinde...");
                client.Connect();
                Console.WriteLine("Forbundet!");
                using (StreamWriter writer = new StreamWriter(client))
                {
                    writer.AutoFlush = true;
                    Console.WriteLine("*** Tast EXIT når du vil stoppe ***");

                    do
                    {
                        Console.Write("Indtast landekode og vekselskurs (f.eks.: DKK100)  : ");
                        _message = Console.ReadLine();
                        writer.WriteLine(_message);
                        Console.WriteLine($"\n{_message} sendt til server!");
                    } while (_message != null && _message.ToUpper() != "EXIT");
                }
            }
        }

    }
}