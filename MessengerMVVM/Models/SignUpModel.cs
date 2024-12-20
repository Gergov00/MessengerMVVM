using MessengerMVVM.DB;
using MessengerMVVM;
using System.Linq;


namespace MessengerMVVM.Models
{
    public class SignUpModel
    {
        string[] EMails = ["@gmail.com", "@yahoo.com", "@hotmail.com", "@aol.com", "@hotmail.co.uk", "@hotmail.fr", "@msn.com", "@yahoo.fr", "@wanadoo.fr", "@orange.fr", "@comcast.net", "@yahoo.co.uk", "@yahoo.com.br", "@yahoo.co.in", "@live.com", "@rediffmail.com", "@free.fr", "@gmx.de", "@web.de", "@yandex.ru", "@ymail.com", "@libero.it", "@outlook.com", "@uol.com.br", "@bol.com.br", "@mail.ru", "@cox.net", "@hotmail.it", "@sbcglobal.net", "@sfr.fr", "@live.fr", "@verizon.net", "@live.co.uk", "@googlemail.com", "@yahoo.es", "@ig.com.br", "@live.nl", "@bigpond.com", "@terra.com.br", "@yahoo.it", "@neuf.fr", "@yahoo.de", "@alice.it", "@rocketmail.com", "@att.net", "@laposte.net", "@facebook.com", "@bellsouth.net", "@yahoo.in", "@hotmail.es", "@charter.net", "@yahoo.ca", "@yahoo.com.au", "@rambler.ru", "@hotmail.de", "@tiscali.it", "@shaw.ca", "@yahoo.co.jp", "@sky.com", "@earthlink.net", "@optonline.net", "@freenet.de", "@t-online.de", "@aliceadsl.fr", "@virgilio.it", "@home.nl", "@qq.com", "@telenet.be", "@me.com", "@yahoo.com.ar", "@tiscali.co.uk", "@yahoo.com.mx", "@voila.fr", "@gmx.net", "@mail.com", "@planet.nl", "@tin.it", "@live.it", "@ntlworld.com", "@arcor.de", "@yahoo.co.id", "@frontiernet.net", "@hetnet.nl", "@live.com.au", "@yahoo.com.sg", "@zonnet.nl", "@club-internet.fr", "@juno.com", "@optusnet.com.au", "@blueyonder.co.uk", "@bluewin.ch", "@skynet.be", "@sympatico.ca", "@windstream.net", "@mac.com", "@centurytel.net", "@chello.nl", "@live.ca", "@aim.com", "@bigpond.net.au"];

        private bool ParseEmal(string emal)
        {
            foreach (var email in EMails)
            {
                if (emal.Contains(email))
                {
                    return true;
                }
            }
            return false;
        }


        public void Register(string userName, string eMail,string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(eMail) || string.IsNullOrWhiteSpace(password))
            {
                ShowMessage.Message("Ошибка", "Заполните все поля!");
                return;
            }

            if (!ParseEmal(eMail))
            {
                ShowMessage.Message("Ошибка", "Введен неверный email");
                return;
            }

            using (var context = new AppDbContext())
            {
                // Проверяем наличие пользователя с таким email или username
                var existingUser = context.users
                    .FirstOrDefault(u => u.email == eMail || u.username == userName);

                if (existingUser != null)
                {
                    ShowMessage.Message("Ошибка", "Пользователь с таким email или username уже существует!");
                    return;
                }

                // Хэшируем пароль
                var hashedPassword = HashPassword.HashedPassword(password);

                // Добавляем нового пользователя
                var user = new User
                {
                    username = userName,
                    email = eMail,
                    passwordhash = hashedPassword
                };

                context.users.Add(user);
                context.SaveChanges();
            }
        }




    }
}
