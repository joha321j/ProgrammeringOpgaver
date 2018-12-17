using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearPowerPlant
{
    public delegate void SendSoundEvent(object sender, EventArgs args);
    class Screen
    {
        public event SendSoundEvent SoundEvent;
        public Screen()
        {
            SoundEvent += Speakers.SendPing;
        }

        public void ShowStatus(object obj, EventArgs eventArgs)
        {
            Console.WriteLine("For the record: {0}", obj);
            SoundEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
