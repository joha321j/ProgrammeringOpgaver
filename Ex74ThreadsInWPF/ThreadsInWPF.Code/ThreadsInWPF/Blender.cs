using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ThreadsInWPF
{
    class Blender
    {
        private bool _running = true;
        private readonly Button _btnBlend;
        private readonly Button _btnClean;
        private readonly Button _btnStop;
        private readonly Label _lblStatus;
        private readonly ListBox _lbBlender;

        public Blender(Button btnBlend, Button btnClean, Button btnStop, Label lblStatus, ListBox lbBlender)
        {
            _btnBlend = btnBlend;
            _btnClean = btnClean;
            _btnStop = btnStop;
            _lblStatus = lblStatus;
            _lbBlender = lbBlender;
        }
        public void Blend()
        {
            _running = true;
            _btnStop.Dispatcher.Invoke(new Action(() => _btnStop.IsEnabled = true));
            _btnBlend.Dispatcher.Invoke(new Action(() => _btnBlend.IsEnabled = false));
            _btnClean.Dispatcher.Invoke(new Action(() => _btnClean.IsEnabled = false));
            int blendTime = 10;
            int i = 0;
            while (_running && i < blendTime)
            {
                var i1 = i;
                _lblStatus.Dispatcher.Invoke(new Action(() => _lblStatus.Content = $"Blending {i1}"));
                Thread.Sleep(1000);
                i++;
            }

            if (_running)
            {
                _lblStatus.Dispatcher.Invoke(new Action(() => _lblStatus.Content = "Juice Ready"));
            }
            
            _btnBlend.Dispatcher.Invoke(new Action(() => _btnBlend.IsEnabled = true));
            _btnClean.Dispatcher.Invoke(new Action(() => _btnClean.IsEnabled = true));
        }

        public void Clean()
        {
            _running = true;
            int cleanTime = _lbBlender.Dispatcher.Invoke(() => _lbBlender.Items.Count);
            int i = 0;
            _btnClean.Dispatcher.Invoke(new Action(() => _btnClean.IsEnabled = false));
            _btnBlend.Dispatcher.Invoke(new Action(() => _btnBlend.IsEnabled = false));
            

            while (_running && i < cleanTime)
            {
                var i1 = i + 1;

                _lblStatus.Dispatcher.Invoke(new Action(() => _lblStatus.Content = $"Cleaning {i1}"));
                Thread.Sleep(2000);
                _lbBlender.Dispatcher.Invoke(() => _lbBlender.Items.RemoveAt(0));
                i++;
            }
        
            Thread.Sleep(1000);
            _lblStatus.Dispatcher.Invoke(new Action(() => _lblStatus.Content = "Cleaned"));
            _btnClean.Dispatcher.Invoke(new Action(() => _btnClean.IsEnabled = true));
            _btnBlend.Dispatcher.Invoke(new Action(() => _btnBlend.IsEnabled = true));
        }

        public void StopBlender()
        {
            _running = false;
        }
    }
}
