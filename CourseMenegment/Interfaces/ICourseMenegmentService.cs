using System;
using System.Collections.Generic;
using System.Text;
using CourseMenegment.Models;
using CourseMenegment.Enums;

namespace CourseMenegment.Interfaces
{
    interface ICourseMenegmentService
    {
        Group[] Groups { get; }

        void AddGroup(GroupType groupType, int limit);
        void AddStudent(string groupno, string fullname, int age, StudentType studentType, bool isonline);
        void EditGroup(string groupno, GroupType groupType, int limit);
        void EditStudent(string groupno, string fullname, int age, StudentType studentType, bool isonline);
        void RemoveStudent(string groupno, string fullname);
    }
}
