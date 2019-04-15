using System;

namespace CodeGenerationLibrary
{
    public static class CodeGen
    {
        //Описание алгоритма
        //Цифро-буквенный код генерируется следующим образом:
        //    1 цифра в коде является номером группы
        //    2,3,4 являются первыми буквами фамилии, имени, отчетсва соответсвенно
        //    последние цифры создаются путем небольших математических операций вида:
        //                                                                z=((x*2)+5)*50
        //                                                                где x-день,
        //                                                                    y-месяц,
        //                                                                    z-результат
        //    В конце алгоритма все полученные строки конкатенируются, создавая единый цифро-буквенный код.
        public static string Encrypt(string name, string l_name, string s_name, string birth_date, int group_num)
        {
            if (group_num > 9) group_num = group_num = 0;
            string encrypted;
            string[] b_day = birth_date.Split('.');
            string last4 = ((Convert.ToInt32(b_day[0]) * 2 + 5) * 50 + Convert.ToInt32(b_day[1])).ToString();
            if (last4.Length < 4) last4 = "0" + last4;
            encrypted = group_num.ToString() + l_name.Substring(0, 1) + name.Substring(0, 1) + s_name.Substring(0, 1) + last4;
            return encrypted;
        }
        public static string Decrypt(string message)
        {
            string b_day;
            string decrypted;
            if (message.Substring(4, 1) == "0")
            {
                b_day = "0" + (Convert.ToInt32(message.Substring(4, 4)) - 250).ToString();
            }
            else
            {
                b_day = (Convert.ToInt32(message.Substring(4, 4)) - 250).ToString();
            }
            string birth_date = b_day.Substring(0, 2) + "." + b_day.Substring(2, 2);
            decrypted = message.Substring(1, 1) + " " + message.Substring(2, 1) + " " + message.Substring(3, 1) + " " + birth_date + " " + message.Substring(0, 1);
            return decrypted;
        }

    }
}
