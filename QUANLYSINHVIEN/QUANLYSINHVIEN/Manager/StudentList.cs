
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYSINHVIEN
{
    public class StudentList
    {
        public List<Student> students;
        public StudentList()
        {
            students = new List<Student>()
            {
                new Student("Maya" ,new DateTime(2000, 02, 01), "HaNoi", 160.7, 70, "20a10060", "hou", 2020, 8),
                new Student("Jenney" ,new DateTime(2004, 1, 6), "HaNoi", 164, 50, "20a100w2", "hauni", 2021, 9),
                new Student("Jobert" ,new DateTime(1999, 1, 1), "London", 180.7, 70, "20a17060", "fpt", 2019, 8),
                new Student("Jacket Hom" ,new DateTime(2002, 10, 1), "New York", 190.7, 90, "20a1900", "hou", 2020, 7),
                new Student("James De" ,new DateTime(2003, 1, 12), "Ho Chi Minh", 160.7, 90, "20a1kds0", "tmu", 2022, 8),
                new Student("Monica Fres" ,new DateTime(2005, 5, 1), "HaNoi", 152, 40, "20a10uu0", "hou", 2022, 5)
            };
        }

        public Student InputHandle()
        {
            string name = GetInput("Please enter name: ", Validation.CheckNameInput);

            string dayOfBirth = GetInput("Please enter birthday (dd/MM/yyyy): ", Validation.CheckBirthdayInput);

            string address = GetInput("Please enter Address: ", Validation.CheckAddressInput);

            string height = GetInput("Please enter height (cm): ", Validation.CheckHeightInput);

            string weight = GetInput("Please enter weight (kg):", Validation.CheckWeightInput);

            string studentCode = GetInput("Please enter StudentCode: ", (input) => Validation.CheckStudentCodeInput(input, students));

            string school = GetInput("Please enter School: ", Validation.CheckSchoolInput);

            string yearStart = GetInput("Please enter year start study (yyyy): ", Validation.CheckYearStartInput);

            string gpa = GetInput("Please enter GPA (double): ", Validation.CheckGpaInput);

            return new Student(name, DateTime.ParseExact(dayOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture), address, double.Parse(height), double.Parse(weight), studentCode, school, int.Parse(yearStart), double.Parse(gpa));
        }

        public void AddStudent()
        {
            Console.WriteLine("*****Add a new student*****");
            Student newStudent = InputHandle();
            try
            {
                students.Add(newStudent);
                ResultCase(true, "add student successfull");
            }
            catch (Exception ex)
            {
                ResultCase(false, $"add student not successfull {ex.Message}");
            }
            var lastStudent = students.Last();
            Console.WriteLine($"student just add {lastStudent}");
        }

        

        public void SearchStudentById()
        {
            Console.WriteLine("-------------Search student by Id------------");
            string id = GetInput("Please enter ID: ", Validation.CheckGenerateId);
            Student studentId = GetStudentById(id);
            if (studentId == null)
            {
                ResultCase(false, "student not found");
            }
            else
            {
                PrintStudent(studentId, "student user search");
            }
        }

        public void UpdateStudentId()
        {
            Console.WriteLine("---------Update student by Id------------");
            string id = GetInput("please enter ID: ", Validation.CheckGenerateId);
            Student studentUpdateData = GetStudentById(id);
            if (studentUpdateData == null)
            {
                ResultCase(false, "student not found");
                return;
            }
            PrintStudent(studentUpdateData, "Student need to update");
            Student updateData = InputHandle();

            studentUpdateData.Name = updateData.Name;
            studentUpdateData.Birthday = updateData.Birthday;
            studentUpdateData.Address = updateData.Address;
            studentUpdateData.Height = updateData.Height;
            studentUpdateData.Weight = updateData.Weight;
            studentUpdateData.StudentCode = updateData.StudentCode;
            studentUpdateData.School = updateData.School;
            studentUpdateData.YearStart = updateData.YearStart;
            studentUpdateData.Gpa = updateData.Gpa;

            ResultCase(true, "Update student successfull!");
            PrintStudent(studentUpdateData, "Student after update");
        }

        public void DeleteStudentId()
        {
            Console.WriteLine("---------Delete student by Id------------");
            string id = GetInput("please enter ID: ", Validation.CheckGenerateId);
            Student studentDelete = GetStudentById(id);
            if (studentDelete == null)
            {
                ResultCase(false, "student not found");
                return;
            }
            students.Remove(studentDelete);
            ResultCase(true, "delete Student successfull!");
            DisplayAllStudent();
        }

        public void DisplayAllStudent()
        {
            Console.WriteLine("--------------List students ---------------");
            if (!students.Any())
            {
                Console.WriteLine("the list empty");
                return;
            }
            students.ForEach(student =>
            {
                Console.WriteLine(student.ToString());
            });
        }
        private Student GetStudentById(string id)
        {
            //ham dung lai
            Student studentId = students.Find(s => s.Id == int.Parse(id));
            return studentId;
        }
        public void DisplayStudentByLevel()
        {
            Console.WriteLine("-------------List student group by Level ----------------");
            var percentLevel = students.GroupBy(student => student.Level)
                                .Select(gr => new
                                {
                                    level = gr.Key,
                                    percenLevel = (double)gr.Count() / students.Count() * 100
                                });
            foreach (var group in percentLevel)
            {
                Console.WriteLine($"Level {group.level} : {group.percenLevel}%");
            }
        }

        public void DisplayStudentByGpa()
        {
            Console.WriteLine("----------------List student group by GPA------------------");
            Dictionary<double?, double> percentGpa = new Dictionary<double?, double>();
            foreach (var student in students)
            {
                if (student.Gpa != null && percentGpa.ContainsKey(student.Gpa))
                {
                    percentGpa[student.Gpa]++;
                }
                else
                {
                    percentGpa.Add(student.Gpa, 1);
                }
            }
            double total = students.Count;
            foreach (var item in percentGpa)
            {
                double percentage = item.Value / total * 100;
                Console.WriteLine($"GPA {item.Key}: {percentage}%");
            }
        }

        public void DisplayStudentByLevelFromKeyboard()
        {
            Console.WriteLine("----------------Get student group by Level from keyboard -------------------");
            string levelst = GetInput("enter level you want to get student(Least,Low, Medium, Middling, Good, Excellent):", Validation.CheckLevelInput);
            List<Student> listLevelStudent = students
                .Where(s => s.Level.ToString().Equals(levelst, StringComparison.OrdinalIgnoreCase)).ToList();
            if (listLevelStudent.Count > 0)
            {
                Console.WriteLine($"list of student for level {levelst}");
                foreach (Student student in listLevelStudent)
                {
                    Console.WriteLine($"Id: {student.Id}- Name: {student.Name}- GPA: {student.Gpa}");
                }
            }
            else
            {
                Console.WriteLine($"have not student for level {levelst}");
            }
        }

        public void SaveFile()
        {
            try
            {
                using (StreamWriter tw = new StreamWriter(ConstantName.FilePath))
                {
                    foreach (Student s in students)
                    {
                        tw.WriteLine(s.ToString());
                    }
                    tw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        private static string GetInput(string prompot, Func<string, Response> validator)
        {
            string input = null;
            bool isValid = false;
            while (!isValid)
            {
                Console.Write(prompot);
                input = Console.ReadLine()?.Trim();
                Response response = validator(input);

                if (!response.success)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(response.message);
                    Console.ResetColor();
                }
                else
                {
                    isValid = true;
                }
            }
            return input;
        }
        private void PrintStudent(Student studentSearch, string mess)
        {
            Console.WriteLine($"-----------{mess}------------");
            Console.WriteLine(studentSearch.ToString());
        }

        private void ResultCase(bool result, string mess)
        {
            if (!result)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(mess);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(mess);
                Console.ResetColor();
            }
        }
    }

}
