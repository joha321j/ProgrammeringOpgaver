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
using Ex28.Application;
using GUI.InsertOwner;
using GUI.InsertPet;
using GUI.ShowPets;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MwInsertPetButton_OnClick(object sender, RoutedEventArgs e)
        {
            MwFrame.Content = InsertPetPage.GetInsertPetPage();
        }

        private void MwInsertOwnerButton_OnClick(object sender, RoutedEventArgs e)
        {
            MwFrame.Content = InsertOwnerPage.GetInsertOwnerPage();
        }


        private void MwShowPetsButton_OnClick(object sender, RoutedEventArgs e)
        {
            MwFrame.Content = ShowPet.GetShowPet();
        }
    }
}
