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

namespace GUI.ShowPets
{
    /// <summary>
    /// Interaction logic for EditPetWindow.xaml
    /// </summary>
    public partial class EditPetWindow : Window
    {
        private string _petId;
        private readonly Controller _controller;
        public EditPetWindow(string[] petInfo)
        {
            InitializeComponent();

            _controller = Controller.GetController();

            _petId = petInfo[0];
            PetNameTextBox.Text = petInfo[1];
            PetTypeTextBox.Text = petInfo[2];
            PetBreedTextBox.Text = petInfo[3];
            PetDobTextBox.Text = petInfo[4];
            PetWeightTextBox.Text = petInfo[5];
            OwnerIdTextBox.Text = petInfo[6];

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

        private void DeletePet_OnClick(object sender, RoutedEventArgs e)
        {
            _controller.DeletePet(_petId);
        }

        private void UpdatePetPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _controller.UpdatePet(_petId, PetNameTextBox.Text, PetTypeTextBox.Text, PetBreedTextBox.Text,
                PetDobTextBox.Text, PetWeightTextBox.Text, OwnerIdTextBox.Text);
        }
    }
}
