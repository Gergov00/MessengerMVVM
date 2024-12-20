using MessengerMVVM.DB;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace MessengerMVVM.Models
{
    public class SignUpModel
    {

        public void Register(string userName, string email,string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Имя пользователя не может быть пустым.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email не может быть пустым.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Пароль не может быть пустым.");

            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
                throw new ArgumentException("Неверный формат электронной почты.");

            if (IsValidPassword(password) || password.Length < 9)
                throw new ArgumentException("Пароль должен содержать как минимум 8 символов.");



            using (var context = new AppDbContext())
            {
                // Проверяем наличие пользователя с таким email или username
                var existingUser = context.users
                    .FirstOrDefault(u => u.email == email || u.username == userName);

                if (existingUser != null)
                {
                    throw new ArgumentException("Пользователь с таким именем пользователя или электронной почтой уже существует.");
                }

                // Хэшируем пароль
                var hashedPassword = HashPassword.HashedPassword(password);

                // Добавляем нового пользователя
                var user = new User
                {
                    username = userName,
                    email = email,
                    passwordhash = hashedPassword
                };

                context.users.Add(user);
                context.SaveChanges();
            }


        }

        private bool IsValidPassword(string password)
        {
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\.@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(password, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }


    }
}
