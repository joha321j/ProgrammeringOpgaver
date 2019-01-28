﻿using System;
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

namespace GUI.ShowPets
{
    /// <summary>
    /// Interaction logic for ShowPet.xaml
    /// </summary>
    public partial class ShowPet : Page
    {
        private List<string> _pets;
        private readonly Controller _controller;
        private static ShowPet _instance;
        private ShowPet()
        {
            InitializeComponent();
            _controller = Controller.GetController();

            UpdatePetList();
        }

        private void UpdatePetList()
        {
            _pets = new List<string>();

            NamePanel.Children.Clear();
            TypePanel.Children.Clear();
            BreedPanel.Children.Clear();
            DobPanel.Children.Clear();
            WeightPanel.Children.Clear();
            OwnerIdPanel.Children.Clear();


            _pets = _controller.GetAllPets();

            foreach (string pet in _pets)
            {
                string[] petInfo = pet.Split(',');
                Label tempLabel = new Label {Content = petInfo[1]};
                NamePanel.Children.Add(tempLabel);

                tempLabel = new Label {Content = petInfo[2]};
                TypePanel.Children.Add(tempLabel);

                tempLabel = new Label {Content = petInfo[3]};
                BreedPanel.Children.Add(tempLabel);

                tempLabel = new Label {Content = petInfo[4]};
                DobPanel.Children.Add(tempLabel);

                tempLabel = new Label() {Content = petInfo[5]};
                WeightPanel.Children.Add(tempLabel);

                tempLabel = new Label() {Content = petInfo[6]};
                OwnerIdPanel.Children.Add(tempLabel);
            }
        }

        public static ShowPet GetShowPet()
        {
            return _instance ?? (_instance = new ShowPet());
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            UpdatePetList();
        }
    }
}
