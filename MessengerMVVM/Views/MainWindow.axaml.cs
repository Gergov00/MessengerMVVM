using Avalonia.Controls;
using Tmds.DBus.Protocol;
using MessengerMVVM.ViewModels;

namespace MessengerMVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}