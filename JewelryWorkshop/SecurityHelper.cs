using System;
using System.Security.Cryptography;
using System.Text;

namespace JewelryWorkshop
{
    public static class SecurityHelper
    {
        // Метод, который превращает любой пароль в необратимый 64-символьный хэш
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                // Превращаем строку пароля в массив байт
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Переводим массив байт в красивую шестнадцатеричную строку
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
