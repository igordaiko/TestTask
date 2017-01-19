using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class UserModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Эти сведения обязательны")]
        [Display(Name = "Имя")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Эти сведения обязательны")]
        [Display(Name = "Фамилия")]
        public string SName { get; set; }
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Эти сведения обязательны")]
        [Display(Name = "Рабочий адрес электронной почты")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Эти сведения обязательны")]
        [Display(Name = "Рабочий адрес номер телефона")]
        [RegularExpression(@"^[+]\d+\([0-9]{3}\)\s[0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Некорректный номер телефона. Номер телефона должен быть в формате +xx(xxx) xxx-xx-xx")]
        public string Phone { get; set; }
        [Display(Name = "Язык")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Эти сведения обязательны")]
        public string EnterpriseName { get; set; }
        [Required(ErrorMessage = "Эти сведения обязательны")]
        public string CountOfUsers { get; set; }

        [Required(ErrorMessage = "Эти сведения обязательны")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Эти сведения обязательны")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Эти сведения обязательны")]
        [Compare("ConfirmPassword", ErrorMessage = "Пароли не совпадают")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Эти сведения обязательны")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }


}