using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class TMan
    {
        private string _name;
        private int _age;
        private string _gender;
        private DateTime _birthDate;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 0)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Вік менше за 0");
                }
            }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public TMan(string name, int age, string gender, DateTime birthDate)
        {
            Name = name;
            Age = age;
            Gender = gender;
            BirthDate = birthDate;
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
            }
        }
        public string this[string propertyName]
        {
            get
            {
                switch (propertyName.ToLower())
                {
                    case "ім'я": return Name;
                    case "вік": return Age.ToString();
                    case "стать": return Gender;
                    default: return "Такого немає";
                }
            }
        }
        public string GetAgeCategory()
        {
            if (Age < 14)
            {
                return "Дитина";
            }
            else if (Age >= 14 && Age < 18)
            {
                return "Юнак";
            }
            else
            {
                return "Доросла людина";
            }
        }
        public string GetZodiacSign()
        {
            int d = BirthDate.Day;
            int m = BirthDate.Month;

            if ((m == 3 && d >= 21) || (m == 4 && d <= 19))
            {
                return "Овен";
            }
            else if ((m == 4 && d >= 20) || (m == 5 && d <= 20)) 
            {
                return "Телець"; 
            }
            else if ((m == 5 && d >= 21) || (m == 6 && d <= 20)) 
            {
                return "Близнюки"; 
            }
            else if ((m == 6 && d >= 21) || (m == 7 && d <= 22)) 
            { 
                return "Рак"; 
            }
            else if ((m == 7 && d >= 23) || (m == 8 && d <= 22)) 
            {
                return "Лев"; 
            }
            else if ((m == 8 && d >= 23) || (m == 9 && d <= 22)) 
            {
                return "Діва"; 
            }
            else if ((m == 9 && d >= 23) || (m == 10 && d <= 22)) 
            {
                return "Терези"; 
            }
            else if ((m == 10 && d >= 23) || (m == 11 && d <= 21)) 
            { 
                return "Скорпіон"; 
            }
            else if ((m == 11 && d >= 22) || (m == 12 && d <= 21)) 
            {
                return "Стрілець"; }
            else if ((m == 12 && d >= 22) || (m == 1 && d <= 19)) 
            {
                return "Козеріг";
            }
            else if ((m == 1 && d >= 20) || (m == 2 && d <= 18)) {
                return "Водолій"; 
            }
            else if ((m == 2 && d >= 19) || (m == 3 && d <= 20)) 
            { 
                return "Риби"; 
            }

            return "Невідомо";
        }
        public override string ToString()
        {
            return $"Особа: {Name}, {Age} років, Стать: {Gender}. " +
                   $"Знак зодіаку: {GetZodiacSign()}. Категорія: {GetAgeCategory()}.";
        }

    }
        internal class Program
        {
            static void Main1(string[] args)
            {
            TMan person1 = new TMan("Олександр", 20, "Чоловіча", new DateTime(2004, 5, 15));
            TMan person2 = new TMan("Марія", 12, "Жіноча", new DateTime(2012, 11, 2));
            Console.WriteLine("Дані об'єктів");
            Console.WriteLine(person1.ToString());
            Console.WriteLine(person2.ToString());

            Console.WriteLine("Перевірка властивостей");
            person1.Name = "Олександр Петрович";
            person1.Age = 21;
            Console.WriteLine($"Нове ім'я першої особи: {person1.Name}, новий вік: {person1.Age}");

            Console.WriteLine("Перевірка індексатора");
            Console.WriteLine($"Отримуємо ім'я через індексатор: {person1["ім'я"]}");
            Console.WriteLine($"Отрим   уємо вік через індексатор: {person1["вік"]}");

            Console.ReadLine();
        }
        }
    }
