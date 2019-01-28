using System;
using System.Windows;
using System.Windows.Controls;
using Ex28.Application;

namespace GUI.InsertOwner
{
    /// <summary>
    /// Interaction logic for InsertOwnerPage.xaml
    /// </summary>
    public partial class InsertOwnerPage : Page
    {
        private static InsertOwnerPage _instance;
        private readonly Controller _controller;
        private InsertOwnerPage()
        {
            InitializeComponent();
            _controller = Controller.GetController();
        }

        public static InsertOwnerPage GetInsertOwnerPage()
        {
            return _instance ?? (_instance = new InsertOwnerPage());
        }

        private void AddOwnerButton_OnClick(object sender, RoutedEventArgs e)
        {
            _controller.AddOwner(LastNameTextBox.Text, FirstNameTextBox.Text, PhoneNrTextBox.Text, EmailTextBox.Text);

            ConfirmationWindow confirmationWindow = new ConfirmationWindow(FirstNameTextBox.Text + " " +LastNameTextBox.Text);
            confirmationWindow.Show();

            LastNameTextBox.Clear();
            FirstNameTextBox.Clear();
            PhoneNrTextBox.Clear();
            EmailTextBox.Clear();
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (LastNameTextBox.Text != string.Empty 
                && FirstNameTextBox.Text != string.Empty 
                && PhoneNrTextBox.Text != string.Empty 
                && EmailTextBox.Text != string.Empty)
            {
                AddOwnerButton.IsEnabled = true;
            }
        }
    }
}
