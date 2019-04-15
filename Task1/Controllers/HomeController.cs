using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeGenerationLibrary;
using Task1.Models;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
      
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Code)
        {
            ViewBag.Alert = false;
            if (!String.IsNullOrEmpty(Code))
            {
                if (Code.Length < 8)
                {
                    ViewBag.Alert = true;
                    ViewBag.Error = "Код должен состоять из 8 символов";
                }
                else
                {
                    string decrypted = CodeGen.Decrypt(Code);
                    if (students_list.ContainsKey(Code))
                    {
                        var std = students_list[Code];
                        ViewBag.result ="ФИО: "+ std.L_Name + " " + std.Name + " " + std.S_Name + ". Дата рождения: " + std.BirthDay.ToShortDateString() + ". Номер группы: " + std.Group_Num;
                    }
                    else
                    {
                        ViewBag.Alert = true;
                        ViewBag.Error = "Ничего не найдено";
                    }
                }
            }
            else
            {
                ViewBag.Alert = true;
                ViewBag.Error = "Введите код";
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetCode()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetCode(Student student)
        {
            ViewBag.Code = CodeGen.Encrypt(student.Name, student.L_Name, student.S_Name, student.BirthDay.ToShortDateString(), student.Group_Num);
            students_list.Add(ViewBag.Code, student);
            return View();
        }
        private Student GetStudent(string decoded)
        {
            Student s1 = new Student();
            return s1;
        }

        private static Dictionary<string, Student> students_list = new Dictionary<string, Student>();
    }
}