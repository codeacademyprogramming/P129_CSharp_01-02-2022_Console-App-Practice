using CourseMenegment.Enums;
using CourseMenegment.Models;
using CourseMenegment.Services;
using System;

namespace CourseMenegment
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseMenegmentService courseMenegmentService = new CourseMenegmentService();

            do
            {
                //Console.BackgroundColor = ConsoleColor.Green;
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("================Xos Gelmisiniz==============\n");
                Console.WriteLine("1. Qrup Elave Et:");
                Console.WriteLine("2. Qrup Uzerinde Deyisiklik Et:");
                Console.WriteLine("3. Butun Qruplari Gosder:");
                Console.WriteLine("4. Telebe Elave Et:");
                Console.WriteLine("5. Telebe Uzerinde Deyisiklik Et:");
                Console.WriteLine("6. Butun Telebelir Gosder:");
                Console.WriteLine("7. Qrup Daxilindeki Telebeleri Gosder:");
                Console.WriteLine("8. Telebeni Sil:");
                Console.WriteLine("9. Sistemden Cixis:\n");
                Console.WriteLine("=======Acilan Menu Pencerisnde Bir Secim Edin. Reqem Daxil Edin:");

                string choose = Console.ReadLine();
                int chooseNum;

                while (!int.TryParse(choose, out chooseNum) || chooseNum < 1 || chooseNum > 9)
                {
                    Console.WriteLine("Duzgun Secim Edin:");
                    choose = Console.ReadLine();
                }

                Console.Clear();

                switch (chooseNum)
                {
                    case 1:
                        AddGroup(ref courseMenegmentService);
                        break;
                    case 2:
                        EditGroup(ref courseMenegmentService);
                        break;
                    case 3:
                        ShowAllGroup(ref courseMenegmentService);
                        break;
                    case 4:
                        AddStudent(ref courseMenegmentService);
                        break;
                    case 5:
                        EditStudent(ref courseMenegmentService);
                        break;
                    case 6:
                        ShowAllStudent(ref courseMenegmentService);
                        break;
                    case 7:
                        ShowAllStudentByGroupNo(ref courseMenegmentService);
                        break;
                    case 8:
                        RemoveStudent(ref courseMenegmentService);
                        break;
                    case 9:
                        return;
                }

            } while (true);
        }

        static void AddGroup(ref CourseMenegmentService courseMenegmentService)
        {
            Console.WriteLine("Qrupun Novunu Sec:");
            foreach (var item in Enum.GetValues(typeof(GroupType)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }

            string grouptypestr = Console.ReadLine();
            int grouptypeNum;

            while (!int.TryParse(grouptypestr, out grouptypeNum) || grouptypeNum < 1 || grouptypeNum > 5)
            {
                Console.WriteLine("Duzgun Secim Edin:");
                grouptypestr = Console.ReadLine();
            }

            GroupType groupType = (GroupType)grouptypeNum;
            Console.WriteLine("Qrupun Limitini Daxil Et:");
            string limitStr = Console.ReadLine();
            int limitNum;

            while (!int.TryParse(limitStr, out limitNum) || limitNum < 10 || limitNum > 18)
            {
                Console.WriteLine("Duzgun Secim Edin:");
                limitStr = Console.ReadLine();
            }

            courseMenegmentService.AddGroup(groupType, limitNum);
        }

        static void EditGroup(ref CourseMenegmentService courseMenegmentService)
        {
            if (courseMenegmentService.Groups.Length > 0)
            {
                Console.WriteLine("=====Qruplarin Siyahisi");
                foreach (Group group in courseMenegmentService.Groups)
                {
                    Console.WriteLine(group);
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("======Once Sisteme Qrup Elave Et:==========");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("Deyisiklik Etmek Isdediyniz Qrupun Nomresini Daxil Et");
            string groupno = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(groupno))
            {
                Console.WriteLine("Duzgun Group Nomresi Daxil Et:");
                groupno = Console.ReadLine();
            }

            Console.WriteLine("Qrupun Novunu Sec:");
            foreach (var item in Enum.GetValues(typeof(GroupType)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }

            string grouptypestr = Console.ReadLine();
            int grouptypeNum;

            while (!int.TryParse(grouptypestr, out grouptypeNum) || grouptypeNum < 1 || grouptypeNum > 5)
            {
                Console.WriteLine("Duzgun Secim Edin:");
                grouptypestr = Console.ReadLine();
            }

            GroupType groupType = (GroupType)grouptypeNum;
            Console.WriteLine("Qrupun Limitini Daxil Et:");
            string limitStr = Console.ReadLine();
            int limitNum;

            while (!int.TryParse(limitStr, out limitNum) || limitNum < 10 || grouptypeNum > 18)
            {
                Console.WriteLine("Duzgun Secim Edin:");
                limitStr = Console.ReadLine();
            }

            courseMenegmentService.EditGroup(groupno,groupType, limitNum);
        }

        static void ShowAllGroup(ref CourseMenegmentService courseMenegmentService)
        {
            if (courseMenegmentService.Groups.Length > 0)
            {
                Console.WriteLine("=====Qruplarin Siyahisi");
                foreach (Group group in courseMenegmentService.Groups)
                {
                    Console.WriteLine(group);
                    Console.WriteLine("================");
                }
            }
            else
            {
                Console.WriteLine("======Once Sisteme Qrup Elave Et:==========");
                return;
            }
        }

        static void AddStudent(ref CourseMenegmentService courseMenegmentService)
        {
            if (courseMenegmentService.Groups.Length > 0)
            {
                Console.WriteLine("=====Qruplarin Siyahisi");
                foreach (Group group in courseMenegmentService.Groups)
                {
                    Console.WriteLine(group);
                }
            }
            else
            {
                Console.WriteLine("======Once Sisteme Qrup Elave Et:==========");
                return;
            }

            Console.WriteLine("Telebeni Elave Etmek Isdediyniz Qrupun Nomresini Daxil Et");
            string groupno = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(groupno))
            {
                Console.WriteLine("Duzgun Group Nomresi Daxil Et:");
                groupno = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Adini Soyadini Daxil Et");
            string fullname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Duzgun Ad Soyad Daxil Et:");
                fullname = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Yasini Daxil Et:");
            string agestr = Console.ReadLine();
            int ageNum;

            while (!int.TryParse(agestr, out ageNum) || ageNum<15 || ageNum > 40)
            {
                Console.WriteLine("Duzgun Yas Daxil Et:");
                agestr = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Novunu Sec:");
            foreach (var item in Enum.GetValues(typeof(StudentType)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }

            string studenttypestr = Console.ReadLine();
            int studenttypeNum;

            while (!int.TryParse(studenttypestr, out studenttypeNum) || studenttypeNum < 1 || studenttypeNum > 2)
            {
                Console.WriteLine("Duzgun Secim Edin:");
                studenttypestr = Console.ReadLine();
            }

            StudentType studentType = (StudentType)studenttypeNum;

            Console.WriteLine("Telebe Onlinedirmi  y/n");
            string isonlinestr = Console.ReadLine();

            while (isonlinestr.ToLower() != "y" && isonlinestr.ToLower() != "n")
            {
                Console.WriteLine("Duzgun Secim Et:");
                isonlinestr = Console.ReadLine();
            }

            bool isonline = isonlinestr.ToLower() == "y";

            courseMenegmentService.AddStudent(groupno, fullname, ageNum, studentType, isonline);
        }

        static void EditStudent(ref CourseMenegmentService courseMenegmentService)
        {
            if (courseMenegmentService.Groups.Length > 0)
            {
                Console.WriteLine("=====Qruplarin Siyahisi");
                foreach (Group group in courseMenegmentService.Groups)
                {
                    Console.WriteLine(group);
                }
            }
            else
            {
                Console.WriteLine("======Once Sisteme Qrup Elave Et:==========");
                return;
            }

            Console.WriteLine("Telebeni Elave Etmek Isdediyniz Qrupun Nomresini Daxil Et");
            string groupno = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(groupno))
            {
                Console.WriteLine("Duzgun Group Nomresi Daxil Et:");
                groupno = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Adini Soyadini Daxil Et");
            string fullname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Duzgun Ad Soyad Daxil Et:");
                fullname = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Yasini Daxil Et:");
            string agestr = Console.ReadLine();
            int ageNum;

            while (!int.TryParse(agestr, out ageNum) || ageNum < 15 || ageNum > 40)
            {
                Console.WriteLine("Duzgun Yas Daxil Et:");
                agestr = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Novunu Sec:");
            foreach (var item in Enum.GetValues(typeof(StudentType)))
            {
                Console.WriteLine($"{(int)item} - {item}");
            }

            string studenttypestr = Console.ReadLine();
            int studenttypeNum;

            while (!int.TryParse(studenttypestr, out studenttypeNum) || studenttypeNum < 1 || studenttypeNum > 2)
            {
                Console.WriteLine("Duzgun Secim Edin:");
                studenttypestr = Console.ReadLine();
            }

            StudentType studentType = (StudentType)studenttypeNum;

            Console.WriteLine("Telebe Onlinedirmi  y/n");
            string isonlinestr = Console.ReadLine();

            while (isonlinestr.ToLower() != "y" && isonlinestr.ToLower() != "n")
            {
                Console.WriteLine("Duzgun Secim Et:");
                isonlinestr = Console.ReadLine();
            }

            bool isonline = isonlinestr.ToLower() == "y";

            courseMenegmentService.EditStudent(groupno, fullname, ageNum, studentType, isonline);
        }

        static void ShowAllStudent(ref CourseMenegmentService courseMenegmentService)
        {
            if (courseMenegmentService.Groups.Length > 0)
            {
                Console.WriteLine("=====Qruplarin Siyahisi");
                foreach (Group group in courseMenegmentService.Groups)
                {
                    if (group.Students.Length > 0)
                    {
                        foreach (Student student in group.Students)
                        {
                            Console.WriteLine(student);
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{group.No} Nomreli Qrupda Telebe Yoxdu");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.WriteLine("======Once Sisteme Qrup Elave Et:==========");
                return;
            }
        }

        static void ShowAllStudentByGroupNo(ref CourseMenegmentService courseMenegmentService)
        {
            if (courseMenegmentService.Groups.Length > 0)
            {
                Console.WriteLine("=====Qruplarin Siyahisi");
                foreach (Group group in courseMenegmentService.Groups)
                {
                    Console.WriteLine(group);
                }
            }
            else
            {
                Console.WriteLine("======Once Sisteme Qrup Elave Et:==========");
                return;
            }

            Console.WriteLine("Telebeni Elave Etmek Isdediyniz Qrupun Nomresini Daxil Et");
            string groupno = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(groupno))
            {
                Console.WriteLine("Duzgun Group Nomresi Daxil Et:");
                groupno = Console.ReadLine();
            }

            foreach (Group group in courseMenegmentService.Groups)
            {
                if (group.No == groupno.Trim().ToUpper())
                {
                    if (group.Students.Length > 0)
                    {
                        foreach (Student student in group.Students)
                        {
                            Console.WriteLine(student);
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Daxil Etdiyniz Qrupda Telebe Yoxdur:");
                        return;
                    }
                }
            }

            Console.WriteLine("Daxil Etdiyniz Qrup Yanlisdir:");
        }

        static void RemoveStudent(ref CourseMenegmentService courseMenegmentService)
        {
            if (courseMenegmentService.Groups.Length > 0)
            {
                Console.WriteLine("=====Qruplarin Siyahisi");
                foreach (Group group in courseMenegmentService.Groups)
                {
                    Console.WriteLine(group);
                }
            }
            else
            {
                Console.WriteLine("======Once Sisteme Qrup Elave Et:==========");
                return;
            }

            Console.WriteLine("Telebeni Elave Etmek Isdediyniz Qrupun Nomresini Daxil Et");
            string groupno = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(groupno))
            {
                Console.WriteLine("Duzgun Group Nomresi Daxil Et:");
                groupno = Console.ReadLine();
            }

            Console.WriteLine("Telebenin Adini Soyadini Daxil Et");
            string fullname = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Duzgun Ad Soyad Daxil Et:");
                fullname = Console.ReadLine();
            }

            courseMenegmentService.RemoveStudent(groupno, fullname);
        }
    }
}
