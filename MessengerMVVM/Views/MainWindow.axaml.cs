using Avalonia.Controls;
using Tmds.DBus.Protocol;
using MessengerMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using MessengerMVVM.Services;

namespace MessengerMVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IServiceProvider serviceProvider) : this()
        {
            var viewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();
            this.DataContext = viewModel;
            viewModel.RequestClose += () => this.Close();
        }
    }
}