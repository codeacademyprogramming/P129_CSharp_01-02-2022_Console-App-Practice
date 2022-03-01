using System;
using System.Collections.Generic;
using System.Text;
using CourseMenegment.Enums;

namespace CourseMenegment.Models
{
    //1-ci Qrup P101, 2-ci D102
    class Group
    {
        private static int _count = 100;
        public string No;
        public GroupType GroupType { get; set; }
        public int Limit { get; set; }
        public Student[] Students;

        public Group(GroupType groupType, int limit)
        {
            Students = new Student[0];
            GroupType = groupType;
            Limit = limit;
            _count++;
            No = $"{char.ToUpper(GroupType.ToString()[0])}{_count}";
        }

        public void AddStudent(Student student)
        {
            if (Students.Length < Limit)
            {
                Array.Resize(ref Students, Students.Length + 1);
                Students[Students.Length - 1] = student;
            }
            else
            {
                Console.WriteLine("Qrupda Yer Yoxdu:");
            }
        }

        public override string ToString()
        {
            return $"Qrupun Nomresi: {No}\nQrupun Novu: {GroupType}\nQrupun Limiti: {Limit}";
        }
    }
}
