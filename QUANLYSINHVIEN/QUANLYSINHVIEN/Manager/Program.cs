using System;
using QUANLYSINHVIEN;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace QUANLYSINHVIEN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentList studentList = new StudentList();
            bool exit = false;
            while (!exit)
            {
                Menu();
                Console.Write("Enter you choose: ");
                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        studentList.AddStudent();
                        break;
                    case "2":
                        studentList.SearchStudentById();
                        break;
                    case "3":
                        studentList.UpdateStudentId();
                        break;
                    case "4":
                        studentList.DeleteStudentId();
                        break;
                    case "5":
                        studentList.DisplayStudentByLevel();
                        break;
                    case "6":
                        studentList.DisplayStudentByGpa();
                        break;
                    case "7":
                        studentList.DisplayStudentByLevelFromKeyboard();
                        break;
                    case "8":
                        studentList.DisplayAllStudent();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("press Enter to continue....");
                Console.ReadLine();
            }
            studentList.SaveFile();
            Console.WriteLine("Exited, press any key to close");
            Console.ReadKey();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("MENU:");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1. Create a new student ");
            Console.WriteLine("2. Search infor of student by id");
            Console.WriteLine("3. Update student by id");
            Console.WriteLine("4. Delete student by id");
            Console.WriteLine("5. Display all student by Level");
            Console.WriteLine("6. Display all student by GPA");
            Console.WriteLine("7. Display students by level get keyboard");
            Console.WriteLine("8. Display all student");
            Console.WriteLine("0. Exit");
            Console.WriteLine("----------------------------------------");
        }
    }
}
