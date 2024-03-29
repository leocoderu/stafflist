﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffList.Models {
    [DisplayName("Новый сотрудник")]
    public class Employees {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо ввести Логин для Авторизации", AllowEmptyStrings = false)]
        [Display(Name = "Логин")]
        [StringLength(50)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Необходимо ввести Пароль для Авторизации", AllowEmptyStrings = false)]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(50,MinimumLength = 8, ErrorMessage = "пароль должен содержать не менее 8 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необходимо ввести подтверждение Пароля", AllowEmptyStrings = false)]
        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Введенные пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Необходимо ввести Имя сотрудника", AllowEmptyStrings = false)]
        [Display(Name="ФИО сотрудника")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Необходимо указать день рождения сотрудника", AllowEmptyStrings = false)]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
                
        [Required]
        [Display(Name = "Пол")]
        public bool Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата приема на работу")]
        public DateTime EnterDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата увольнения с работы")]
        public DateTime LeaveDate { get; set; }

        [Required]
        [Display(Name = "Наличие автомобиля")]
        public bool Automobile { get; set; }

        [Required]
        [Display(Name = "Семейное положение")]
        public bool Married { get; set; }

        [Required]
        [Display(Name = "Отдел")]
        public Department Department { get; set; }

        [Required]
        [Display(Name = "Должность")]
        public Position Position { get; set; }

        [Required(ErrorMessage ="Необходимо указать электроннцю почту", AllowEmptyStrings = false)]
        [Display(Name = "Эл. почта")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage ="Пожалуйста укажите корректный адрес")]
        public string EMail { get; set; }

        [Display(Name = "Комментарии")]
        [UIHint("MultilineText")]
        public string Comments { get; set; }
    }

    public class Department {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Отдел")]
        public string Name { get; set; }
    }

    public class Position {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Должность")]
        public string Name { get; set; }
    }
}