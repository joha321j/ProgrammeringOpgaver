using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace HTTPClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller _controller;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateMessageReceivedTextBox(object sender, EventArgs e)
        {
            string message = sender.ToString();
            MessageReceived.AppendText(message);
            MessageReceived.AppendText(Environment.NewLine);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {

            string message = SendMessage.Text;

            _controller?.SendMessage(message);
        }

        private void ConnectButtonClick(object sender, RoutedEventArgs e)
        {
            string address = AddressBox.Text;
            int port = int.Parse(PortBox.Text);
            _controller = new Controller(address, port);

            _controller.ResponseEventHandler += UpdateMessageReceivedTextBox;

            SendButton.IsEnabled = true;
            ConnectButton.IsEnabled = false;
        }
    }
}
