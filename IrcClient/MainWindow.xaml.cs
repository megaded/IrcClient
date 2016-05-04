﻿using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using MultiChat.Model;
using IrcClient.ViewModel;
using System.Windows.Controls;

namespace IrcClient
{
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel;                       
        }
    }
}
