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
using System.Windows.Shapes;
using Ex28.Application;

namespace GUI.InsertPet
{
    /// <summary>
    /// Interaction logic for AddPetWindow.xaml
    /// </summary>
    public partial class AddPetWindow : Window
    {

        private readonly Controller _controller;
        public AddPetWindow()
        {
            InitializeComponent();
            _controller = Controller.GetController();
        }

        private void PetPageTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (PetNameTextBox.Text != string.Empty
                && PetBreedTextBox.Text != string.Empty
                && PetDobTextBox.Text != string.Empty
                && PetTypeTextBox.Text != string.Empty
                && PetWeightTextBox.Text != string.Empty
                && OwnerIdTextBox.Text != string.Empty)
            {
                InsertPetPageButton.IsEnabled = true;
            }
        }

        private void InsertPetPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _controller.AddPet(PetNameTextBox.Text, PetTypeTextBox.Text, PetBreedTextBox.Text,
                PetDobTextBox.Text, PetWeightTextBox.Text, OwnerIdTextBox.Text);
            ConfirmationWindow confirmationWindow = new ConfirmationWindow(PetNameTextBox.Text);
            confirmationWindow.Show();

            PetNameTextBox.Clear();
            PetTypeTextBox.Clear();
            PetBreedTextBox.Clear();
            PetDobTextBox.Clear();
            PetWeightTextBox.Clear();
            OwnerIdTextBox.Clear();

        }
    }
}
