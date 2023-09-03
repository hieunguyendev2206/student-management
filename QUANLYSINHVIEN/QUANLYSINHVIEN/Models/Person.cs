using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using static System.Net.WebRequestMethods;

namespace QUANLYSINHVIEN
{
    public class Person
    {
        // variable of person: id, name, birthday, address, height, weight
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }

        //constructor
        public Person(string name, DateTime birthday, string address, double height, double weight)
        {
            Name = name;
            Birthday = birthday;
            Address = address;
            Height = height;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Id, 3}\t{Name, 20}\t{Birthday, 8}\t{Address,15}\t{Height,5}\t{Weight, 5}";
        }
    }
    
}
