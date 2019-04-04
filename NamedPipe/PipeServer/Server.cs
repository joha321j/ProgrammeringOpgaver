using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PipeServer
{
    class Server
    {
        private StreamReader _pipeReader;
        private bool _running = true;
        private string _input = String.Empty;
        private readonly List<Currency> _currencies = new List<Currency>();

        public void Run(string pipeName)
        {
            Console.Write("Venter på klient...");
            using (NamedPipeServerStream server = new NamedPipeServerStream(pipeName))
            {
                //Wait for client to connect
                server.WaitForConnection();
                Console.WriteLine(" - klient tilsluttet!");

                using (_pipeReader = new StreamReader(server))
                {
                    while (_running)
                    {
                        Console.WriteLine("Venter på input...");
                        _input = GetLineFromClient(_pipeReader);
                        _running = ManageInput(_input);
                    }
                }
            }
        }

        private string GetLineFromClient(StreamReader reader)
        {
            string result = string.Empty;
            while (reader.Peek() >= 0)
            {
                result += reader.ReadLine();
            }
            reader.DiscardBufferedData();
            return result.ToUpper();
        }

        private bool ManageInput(string input)
        {
            if (string.Equals(input.ToUpper(), "EXIT"))
            {
                return false;
            }

            Console.WriteLine("\nInput var: " + input);

            Match match = Regex.Match(input, @"([|A-Z|a-z| ]*)([\d]*)");
            string countryCode = match.Groups[1].Value;
            var value = int.Parse(match.Groups[2].Value);

            AddCurrency(countryCode, value);
            return true;
        }

        private void AddCurrency(string countryCode, int value)
        {
            _currencies.Add(new Currency(countryCode, value));

            ShowCurrencies();
        }

        private void ShowCurrencies()
        {
            Console.WriteLine("\nValutakurser: ");
            foreach (Currency c in _currencies)
            {
                Console.WriteLine($"{c.CountryCode}, {c.ExchangeRate}");
            }
        }
    }
}
