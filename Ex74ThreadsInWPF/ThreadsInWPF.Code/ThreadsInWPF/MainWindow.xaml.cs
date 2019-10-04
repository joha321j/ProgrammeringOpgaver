using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ThreadsInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Blender _blenderOne;
        private readonly Blender _blenderTwo;
        public MainWindow()
        {
            InitializeComponent();
            _blenderOne = new Blender(btnBlend1, btnClean1, btnStop1, lblStatus1, lbBlender1);
            _blenderTwo = new Blender(btnBlend2, btnClean2, btnStop2, lblStatus2, lbBlender2);
        }

        private void BtnPutIn1_Click(object sender, RoutedEventArgs e)
        {
            if (lbFruits.SelectedItem != null)
            {
                var fruit = (lbFruits.SelectedItem as ListBoxItem)?.Content;
                lbBlender1.Items.Add(new ListBoxItem {Content = fruit});
            }
        }

        private void BtnPutIn2_Click(object sender, RoutedEventArgs e)
        {
            if (lbFruits.SelectedItem != null)
            {
                var fruit = (lbFruits.SelectedItem as ListBoxItem)?.Content;
                lbBlender2.Items.Add(new ListBoxItem {Content = fruit});
            }
        }

        private void BtnBlend1_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() => _blenderOne.Blend());
            thread.Start();
        }

        private void BtnBlend2_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() => _blenderTwo.Blend());
            thread.Start();
        }

        private void BtnClean1_OnClick(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() => _blenderOne.Clean());
            thread.Start();

        }

        private void BtnClean2_OnClick(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() => _blenderTwo.Clean());
            thread.Start();
        }

        private void BtnStop1_OnClick(object sender, RoutedEventArgs e)
        {
            _blenderOne.StopBlender();
            lblStatus1.Content = "Stopped!";
            btnStop1.IsEnabled = false;
        }

        private void BtnStop2_OnClick(object sender, RoutedEventArgs e)
        {
            _blenderTwo.StopBlender();
            lblStatus2.Content = "Stopped!";
            btnStop2.IsEnabled = false;
        }

        private void PrgBar1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
