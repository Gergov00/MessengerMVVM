using System.ComponentModel;
using MessengerMVVM.Models;

namespace MessengerMVVM.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Greeting { get; } = "Welcome to Avalonia!";

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _number1;
        public int Number1 {
            get
            {
                return _number1;
            }
            set
            {
                _number1 = value;
                OnPropertyChanged("Number3");
            }
        }

        private int _number2;
        public int Number2
        {
            get
            {
                return _number2;
            }
            set
            {
                _number2 = value;
                OnPropertyChanged("Number3");
            }
        }

        public int Number3
        {
            get
            {
                return MathFunc.Sum(Number1, Number2);
            }
        }
    }
}
