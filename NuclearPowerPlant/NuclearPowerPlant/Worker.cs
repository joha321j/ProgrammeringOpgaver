using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearPowerPlant
{
    public delegate void WorkerDelegate(object sender, EventArgs args);
    class Worker
    {
        public enum Status
        {
            Alive,
            Radiated,
            Dying,
            Dead,
            NotAtWork
        }

        private readonly Status _status;
        public string Name;
        public event WorkerDelegate WorkerMessage;

        public Worker(Status status, string name, Screen screen)
        {
            _status = status;
            Name = name;
            WorkerMessage += screen.ShowStatus;
        }

        private string GetStatus()
        {
            return AmAlive();
        }

        private string AmAlive()
        {
            return "For the record: " + Name + " is alive";
        }

        public void SendStatus()
        {
            WorkerMessage?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return GetStatus();
        }
    }
}
