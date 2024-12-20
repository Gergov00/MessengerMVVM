using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MessengerMVVM.ViewModels;

namespace MessengerMVVM;

public partial class SignUp : Window
{
    public SignUp()
    {
        InitializeComponent();
        DataContext = new SignUpViewModel();
    }
}