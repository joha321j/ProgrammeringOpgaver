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

namespace SimpleGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Random GetRandom = new Random();
        public MainWindow()
        {
            InitializeComponent();
            Title = "SimpleGUI";
        }

        private void ScrollUp_Click(object sender, RoutedEventArgs e)
        {
            string tempString = BoxOne.Text;
            BoxOne.Text = BoxTwo.Text;
            BoxTwo.Text = BoxThree.Text;
            BoxThree.Text = BoxFour.Text;
            BoxFour.Text = tempString;

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            BoxOne.Clear();
            BoxTwo.Clear();
            BoxThree.Clear();
            BoxFour.Clear();
        }

        private void ScrollDown_OnClick(object sender, RoutedEventArgs e)
        {
            string tempString = BoxFour.Text;
            BoxFour.Text = BoxThree.Text;
            BoxThree.Text = BoxTwo.Text;
            BoxTwo.Text = BoxOne.Text;
            BoxOne.Text = tempString;
        }

        private void Random_OnClick(object sender, RoutedEventArgs e)
        {
            List<string> textList = new List<string>(4);

            textList.Add(BoxOne.Text);
            textList.Add(BoxTwo.Text);
            textList.Add(BoxThree.Text);
            textList.Add(BoxFour.Text);

            int rand = GetRandomNumber(0, 4);
            BoxOne.Text = textList[rand];
            textList.RemoveAt(rand);

            rand = GetRandomNumber(0, 3);
            BoxTwo.Text = textList[rand];
            textList.RemoveAt(rand);

            rand = GetRandomNumber(0, 2);
            BoxThree.Text = textList[rand];
            textList.RemoveAt(rand);

            BoxFour.Text = textList[0];
            textList.RemoveAt(0);

        }

        private static int GetRandomNumber(int min, int max)
        {
            lock (GetRandom)
            {
                return GetRandom.Next(min, max);
            }
        }
    }
}
