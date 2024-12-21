using Avalonia.Controls;
using MessengerMVVM.Services;
using MessengerMVVM.Services.Implementations;
using MessengerMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MessengerMVVM.Views;

public partial class SignUp : Window
{
    public SignUp()
    {
        InitializeComponent();
    }

    public SignUp(IServiceProvider serviceProvider) : this()
    {
        var viewModel = serviceProvider.GetRequiredService<SignUpViewModel>();
        this.DataContext = viewModel;
        viewModel.RequestClose += () => this.Close();
    }
}