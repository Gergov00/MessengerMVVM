using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MessengerMVVM.Services;
using MessengerMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MessengerMVVM.Views;

public partial class LogIn : Window
{
    public LogIn()
    {
        InitializeComponent();
    }

    public LogIn(IServiceProvider serviceProvider) : this()
    {
        var viewModel = serviceProvider.GetRequiredService<LogInViewModel>();
        this.DataContext = viewModel;
        viewModel.RequestClose += () => this.Close();
    }
}