using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Task1.Models
{
    public class Student
    {
        [DisplayName("Имя")]
        [Required(ErrorMessage = "Укажите имя")]
        public string Name { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Укажите фамилию")]
        public string L_Name { get; set; }

        [DisplayName("Отчество")]
        [Required(ErrorMessage = "Укажите отчество")]
        public string S_Name { get; set; }

        [DisplayName("Дата рождения")]
        [Required(ErrorMessage = "Укажите дату рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [DisplayName("Номер группы")]
        [Required(ErrorMessage = "Укажите номер группы")]
        public int Group_Num { get; set; }
    }
}