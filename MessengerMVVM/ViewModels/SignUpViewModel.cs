using MessengerMVVM.Models;
using MessengerMVVM.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace MessengerMVVM.ViewModels
{
    public class SignUpViewModel : BindableBase
    {
        string[] EMails = ["@gmail.com", "@yahoo.com", "@hotmail.com", "@aol.com", "@hotmail.co.uk", "@hotmail.fr", "@msn.com", "@yahoo.fr", "@wanadoo.fr", "@orange.fr", "@comcast.net", "@yahoo.co.uk", "@yahoo.com.br", "@yahoo.co.in", "@live.com", "@rediffmail.com", "@free.fr", "@gmx.de", "@web.de", "@yandex.ru", "@ymail.com", "@libero.it", "@outlook.com", "@uol.com.br", "@bol.com.br", "@mail.ru", "@cox.net", "@hotmail.it", "@sbcglobal.net", "@sfr.fr", "@live.fr", "@verizon.net", "@live.co.uk", "@googlemail.com", "@yahoo.es", "@ig.com.br", "@live.nl", "@bigpond.com", "@terra.com.br", "@yahoo.it", "@neuf.fr", "@yahoo.de", "@alice.it", "@rocketmail.com", "@att.net", "@laposte.net", "@facebook.com", "@bellsouth.net", "@yahoo.in", "@hotmail.es", "@charter.net", "@yahoo.ca", "@yahoo.com.au", "@rambler.ru", "@hotmail.de", "@tiscali.it", "@shaw.ca", "@yahoo.co.jp", "@sky.com", "@earthlink.net", "@optonline.net", "@freenet.de", "@t-online.de", "@aliceadsl.fr", "@virgilio.it", "@home.nl", "@qq.com", "@telenet.be", "@me.com", "@yahoo.com.ar", "@tiscali.co.uk", "@yahoo.com.mx", "@voila.fr", "@gmx.net", "@mail.com", "@planet.nl", "@tin.it", "@live.it", "@ntlworld.com", "@arcor.de", "@yahoo.co.id", "@frontiernet.net", "@hetnet.nl", "@live.com.au", "@yahoo.com.sg", "@zonnet.nl", "@club-internet.fr", "@juno.com", "@optusnet.com.au", "@blueyonder.co.uk", "@bluewin.ch", "@skynet.be", "@sympatico.ca", "@windstream.net", "@mac.com", "@centurytel.net", "@chello.nl", "@live.ca", "@aim.com", "@bigpond.net.au"];

        private readonly SignUpModel _model;


        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public DelegateCommand SignUpCommand { get; }
        public DelegateCommand GoLogInPage { get; }

        public SignUpViewModel()
        {
            _model = new SignUpModel();

            //GoLogInPage = new DelegateCommand(, CanExecuteSignUp);
            SignUpCommand = new DelegateCommand(ExecuteSignUp, CanExecuteSignUp)
            .ObservesProperty(() => Username)
            .ObservesProperty(() => Email)
            .ObservesProperty(() => Password);
            
          
        }
        

        

        private void ExecuteSignUp()
        {
            try
            {
                _model.Register(Username, Email, Password);
                new MainWindow().Show();
                
            }
            catch (ArgumentException ex)
            {
                ShowMessage.Message("Ошибка регистарации", ex.Message);
            }

        }

        private bool CanExecuteSignUp()
        {
            return true;
        }


    }
}
