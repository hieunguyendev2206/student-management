

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace QUANLYSINHVIEN
{
    public enum Level
    {
        Least,
        Low,
        Medium,
        Middling,
        Good,
        Excellent
    }
    public class Student : Person
    {
        private static int _stId = 0;
        public string StudentCode { get; set; }
        public string School { get; set; }
        public int YearStart { get; set; }
        public double? Gpa { get; set; }
        public Level Level { get; set; }
        public Student(string name, DateTime birthday, string address, double height, double weight,
                       string studentCode, string school, int yearstart, double gpa)
                       : base(name, birthday, address, height, weight)
        {
            Id = GenerateId();
            StudentCode = studentCode;
            School = school;
            YearStart = yearstart;
            Gpa = gpa;
            Level = LevelStudent(gpa);
        }

        private int GenerateId()
        {
            return _stId++;
        }

        private Level LevelStudent(double gpa)
        {
            if (gpa < 3) 
                return Level.Least;
            if (gpa < 5) 
                return Level.Low;
            if (gpa < 6.5) 
                return Level.Medium;
            if (gpa < 7.5) 
                return Level.Middling;
            if (gpa < 9) 
                return Level.Good;

            return Level.Excellent;
        }

        public override string ToString()
        {
            return $"{Id,-3} {Name,-20} {Birthday.ToString("dd/MM/yyyy"),-15} {Address,-15} {Height,-8} {Weight,-8} {StudentCode,-10} {School,-10} {YearStart,-8} {Gpa,-8}";
        }

    }
}
