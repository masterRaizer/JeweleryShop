using System;

namespace JewelryWorkshop.Models
{
    // 1. Роли пользователей в системе
    public enum UserRole
    {
        Пользователь,
        Мастер
    }

    // 2. Статусы заявок
    public enum RequestStatus
    {
        Новая,
        В_Работе,
        Готова_к_выдаче,
        Отклонена
    }

    // 3. Класс Пользователя
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public bool VerifyPassword(string inputPassword)
        {
            return this.Password == inputPassword;
        }
    }

    // 4. Базовый класс Заявки
    public abstract class Request
    {
        public int Id { get; set; }
        public string ClientLogin { get; set; }
        public string ContactData { get; set; }
        public DateTime DateCreated { get; set; }
        public RequestStatus Status { get; set; }
    }

    // 5. Заявка на изготовление
    public class RequestManufacturing : Request
    {
        public string JewelryType { get; set; }
        public string MetalType { get; set; }
        public string GemsDescription { get; set; }
    }

    // 6. Заявка на ремонт
    public class RequestRepair : Request
    {
        public string TypeOfDamage { get; set; }
        public double EstimatedPrice { get; set; }

        public void CalculateRepairPrice()
        {
            if (TypeOfDamage.ToLower().Contains("пайка")) EstimatedPrice = 1500;
            else if (TypeOfDamage.ToLower().Contains("камень")) EstimatedPrice = 3000;
            else EstimatedPrice = 1000; // Базовая цена
        }
    }
}
