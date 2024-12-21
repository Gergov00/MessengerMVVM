using Avalonia.Interactivity;
using MessengerMVVM.DB;
using MessengerMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMVVM.Models
{
    public class LogInModel
    {
        public void LogIn(string usernameOrEmail, string password)
        {
            

            if (string.IsNullOrWhiteSpace(usernameOrEmail)) 
                throw new ArgumentNullException("Имя пользователя или email не может быть пустым");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Пароль не может быть пустым");

            var hasPassword = HashPassword.HashedPassword(password);

            // Проверка учетных данных
            using (var context = new AppDbContext())
            {
                var user = context.users
                    .FirstOrDefault(u => (u.username == usernameOrEmail || u.email == usernameOrEmail) && u.passwordhash == hasPassword);

                if (user == null) 
                    throw new ArgumentException("Неверный логин/email или пароль");
                
            }
        }
    }
}
