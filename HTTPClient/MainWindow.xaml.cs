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
        private readonly Controller _controller;
        public MainWindow()
        {
            InitializeComponent();

            _controller = new Controller();

            _controller.ResponseEventHandler += UpdateMessageReceivedTextBox;
        }

        private void UpdateMessageReceivedTextBox(object sender, EventArgs e)
        {
            MessageReceived.Content = sender;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string address = AddressBox.Text;
            int port = int.Parse(PortBox.Text);
            string message = SendMessage.Text;

            _controller.SendMessage(address, port, message);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
