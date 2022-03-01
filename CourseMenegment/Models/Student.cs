using System;
using System.Collections.Generic;
using System.Text;
using CourseMenegment.Enums;

namespace CourseMenegment.Models
{
    class Student
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public StudentType StudentType { get; set; }
        public bool IsOnline { get; set; }
        public string GroupName { get; set; }

        public Student(string fullname, int age, StudentType studentType, bool isOnline, string groupname)
        {
            FullName = fullname.Trim().ToUpper();
            Age = age;
            StudentType = studentType;
            IsOnline = isOnline;
            GroupName = groupname.ToUpper();
        }

        public override string ToString()
        {
            string isWaranty = (int)StudentType == 1 ? "Zemanetli" : "Zemanetsiz";
            string isOnline = IsOnline ? "Online" : "Ofline";

            return $"Ad Soyad: {FullName}" +
                $"\nYasi: {Age}" +
                $"\nZemanet Novu: {isWaranty}" +
                $"\nTehsil Novu: {isOnline}" +
                $"\nQrupun Adi:{GroupName}";
        }
    }
}
