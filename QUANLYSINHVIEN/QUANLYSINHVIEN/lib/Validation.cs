using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYSINHVIEN
{
    public class Validation
    {

        public static Response CheckGenerateId(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return new Response(false,"z");
            }
            if (!int.TryParse(id, out int convertId))
            {
                return new Response(false, "not interger");
            }
            if (convertId < 0)
            {
                return new Response(false, "id must interger ");
            }
            return new Response(true, "");
        }

        public static Response CheckNameInput(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return new Response(false, "not null or not have whitespace");
            }
            if (name.Length > ConstantName.MaxLenghtName)
            {
                return new Response(false, $"lenght of name {ConstantName.MaxLenghtName}");
            }
            return new Response(true, "");
        }

        public static Response CheckBirthdayInput(string yearofbirth)
        {
            if (string.IsNullOrEmpty(yearofbirth) || string.IsNullOrWhiteSpace(yearofbirth))
            {
                return new Response(false, "not null or not have whitespace");
            }
            if (!DateTime.TryParse(yearofbirth, out DateTime convertBirday))
            {
                return new Response(false,"cannot convert to type datetime");
            }
            if (convertBirday.Year < ConstantName.MinYearBirth)
            {
                return new Response(false, $"year > {ConstantName.MinYearBirth}");
            }
            return new Response(true, "");
        }

        public static Response CheckAddressInput(string address)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            {
                return new Response(false, "not null or not have whitespace");
            }
            if (address.Length > ConstantName.MaxLenghtAddress)
            {
                return new Response(false, $"address < {ConstantName.MaxLenghtAddress}");
            }
            return new Response(true, "");
        }

        public static Response CheckHeightInput(string height)
        {
            if (string.IsNullOrEmpty(height) || string.IsNullOrWhiteSpace(height))
            {
                return new Response(false, "not null or not have whitespace");
            }
            if (!double.TryParse(height, out double convertHeight))
            {
                return new Response(false, "must double!");
            }
            if (convertHeight < ConstantName.MinHeight || convertHeight > ConstantName.MaxHeight)
            {
                return new Response(false, $"{ConstantName.MinHeight} < height < {ConstantName.MaxHeight}");
            }
            return new Response(true, "");
        }

        public static Response CheckWeightInput(string weight)
        {

            if (string.IsNullOrEmpty(weight) || string.IsNullOrWhiteSpace(weight))
            {
                return new Response(false, "not null or not have whitespace");
            }
            if (!double.TryParse(weight, out double convertWeight))
            {
                return new Response(false, "must double!");
            }
            if (convertWeight < ConstantName.MinWeight || convertWeight > ConstantName.MaxWeight)
            {
                return new Response(false, $"{ConstantName.MinWeight} < weight < ${ConstantName.MaxWeight}");
            }
            return new Response(true, "");
        }

        public static Response CheckStudentCodeInput(string idStudent, List<Student> students)
        {
            if (string.IsNullOrEmpty(idStudent) || string.IsNullOrWhiteSpace(idStudent))
            {
                return new Response(false, "not null or not have whitespace");
            }
            if (idStudent.Length > ConstantName.MaxLenghtStudentCode)
            {
                return new Response(false, $"lenght of student code < {ConstantName.MaxLenghtStudentCode}");
            }
            if (students.Any(student => student != null && student.StudentCode == idStudent))
            {
                return new Response(false, $"student code must identify ");
            }
            return new Response(true,"");
        }

        public static Response CheckSchoolInput(string school)
        {
            if (string.IsNullOrEmpty(school) || string.IsNullOrWhiteSpace(school))
            {
                return new Response(false, "not null or not have whitespace");
            }
            if (school.Length > ConstantName.MaxLenghtSchool)
            {
                return new Response(false, $"lenght of school < {ConstantName.MaxLenghtSchool}");
            }
            return new Response(true, "");
        }

        public static Response CheckYearStartInput(string yearStart)
        {
            if (string.IsNullOrEmpty(yearStart) || string.IsNullOrWhiteSpace(yearStart))
            {
                return new Response(false, "not null or not have whitespace");
            }
            if (yearStart.Length != ConstantName.LenghtYearStart)
            {
                return new Response(false, "not correct format of year");
            }
            if (!int.TryParse(yearStart,out int convertyear))
            {
                return new Response(false, "not interger");
            }
            return new Response(true, "");
        }

        public static Response CheckGpaInput(string gpa)
        {
            double  convertgpa;
            if(!double.TryParse(gpa, out convertgpa))
            {
                return new Response(false, "not double or not have whitespace");
            }
            if(convertgpa < ConstantName.MinGpa || convertgpa > ConstantName.MaxGpa)
            {
                return new Response(false, $"gpa from {ConstantName.MinGpa} to {ConstantName.MaxGpa}");
            }
            return new Response(true, "");
        }
        public static Response CheckLevelInput(string level)
        {
            if (string.IsNullOrEmpty(level) || string.IsNullOrWhiteSpace(level))
            {
                return new Response(false, "not  null or not have whitespace");
            }
            return new Response(true, "");
        }

        public static Response CheckMenu (string menu)
        {
            if (!string.IsNullOrEmpty(menu))
            {
                return new Response(false, "not empty!!!");
            }
            return new Response(true, "");
        }
    }

}
