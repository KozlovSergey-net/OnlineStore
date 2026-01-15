using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OnlineStore.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = $"Пароль должен иметь: минимум 8 символов, " +
            $"хотя бы одну верхнюю английскую букву, " +
            $"хотя бы одну нижнюю английскую букву, " +
            $"хотя бы одну цифру, " +
            $"хотя бы один специальный символ.")]


        public string? Password { get; set; }
    }
}
