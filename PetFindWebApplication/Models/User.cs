using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetFindWebApplication.Models
{
    public class User
    {
        [Display(Name = "Пользователь")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string Username { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Почта введена не корректно")]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 7)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Мобильный номер")]
        public string TelNumber { get; set; }
        public List<Advertisement> Advertisements { get; set; }
    }
}
