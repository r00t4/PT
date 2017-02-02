using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1._2
{
    class Student
    {
        public string name, surname;
        public int age;
        public double gpa;
        public Student(string name, string surname, int age, double gpa)
        {
            this.age = age;
            this.name = name;
            this.surname = surname;
            this.gpa = gpa;
        }
        public override string ToString()
        {
            return name + " " + surname + " " + age + " " + gpa;
        }

    }
    class Program
    {   
        static void Main(string[] args)
        {
            Student s = new Student("LOL", "Kek", 19, 2.9);
            Console.WriteLine(s.name);
            Console.WriteLine(s.age);
            Console.ReadKey();
        }
    }
    
}
