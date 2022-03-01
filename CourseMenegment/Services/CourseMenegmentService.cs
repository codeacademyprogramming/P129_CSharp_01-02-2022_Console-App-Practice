using CourseMenegment.Enums;
using CourseMenegment.Interfaces;
using CourseMenegment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseMenegment.Services
{
    class CourseMenegmentService : ICourseMenegmentService
    {
        private Group[] _groups;
        public Group[] Groups => _groups;

        public CourseMenegmentService()
        {
            _groups = new Group[0];
        }

        public void AddGroup(GroupType groupType, int limit)
        {
            //Group group = new Group(groupType, limit);

            Array.Resize(ref _groups, _groups.Length + 1);
            _groups[_groups.Length - 1] = new Group(groupType, limit);
        }

        public void AddStudent(string groupno, string fullname, int age, StudentType studentType, bool isonline)
        {
            Group group = null;

            foreach (Group item in _groups)
            {
                if (item.No == groupno.Trim().ToUpper())
                {
                    group = item;
                }
            }

            if (group != null)
            {
                Student student = new Student(fullname, age, studentType, isonline, groupno);
                group.AddStudent(student);
                return;
            }
            Console.WriteLine("Daxil Edilen Nomreli Qrup Tapilmadi:");
        }

        public void EditGroup(string groupno, GroupType groupType, int limit)
        {
            foreach (Group group in _groups)
            {
                if (group.No == groupno.Trim().ToUpper())
                {
                    if (group.Students.Length <= limit)
                    {
                        group.Limit = limit;
                    }
                    else
                    {
                        Console.WriteLine("Yeni Limit Uygun Deyil:");
                    }

                    group.GroupType = groupType;
                    group.No = group.No.Replace(group.No[0], char.ToUpper(groupType.ToString()[0]));

                    foreach (Student student in group.Students)
                    {
                        student.GroupName = group.No;
                    }
                    return;
                }
            }

            Console.WriteLine("Daxil Edilen Nomreli Qrup Tapilmad:");
        }

        public void EditStudent(string groupno, string fullname, int age, StudentType studentType, bool isonline)
        {
            foreach (Group group in _groups)
            {
                if (group.No == groupno.Trim().ToUpper())
                {
                    foreach (Student student in group.Students)
                    {
                        if (student.FullName == fullname.Trim().ToUpper())
                        {
                            student.Age = age;
                            student.StudentType = studentType;
                            student.IsOnline = isonline;
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("Daxil Edilen Telebe Tapilmadi:");
        }

        public void RemoveStudent(string groupno, string fullname)
        {
            foreach (Group group in _groups)
            {
                if (group.No == groupno.Trim().ToUpper())
                {
                    for (int i = 0; i < group.Students.Length; i++)
                    {
                        if (group.Students[i].FullName == fullname.Trim().ToUpper())
                        {
                            group.Students[i] = null;

                            group.Students[i] = group.Students[group.Students.Length - 1];

                            Array.Resize(ref group.Students, group.Students.Length - 1);

                            return;
                        }
                    }
                }
            }

            Console.WriteLine("Silmek Isdediyniz Telebe Tapilmadi");
        }
    }
}
