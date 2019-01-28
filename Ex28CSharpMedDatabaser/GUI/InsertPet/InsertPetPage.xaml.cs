using System.Windows;
using System.Windows.Controls;
using Ex28.Application;

namespace GUI.InsertPet
{
    /// <summary>
    /// Interaction logic for InsertPetPage.xaml
    /// </summary>
    public partial class InsertPetPage : Page
    {
        private static InsertPetPage _instance;

        private readonly Controller _controller;

        private InsertPetPage()
        {
            InitializeComponent();
            _controller = Controller.GetController();
        }

        public static InsertPetPage GetInsertPetPage()
        {
            return _instance ?? (_instance = new InsertPetPage());
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
    }
}
