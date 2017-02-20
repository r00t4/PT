using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LAB4
{
    [Serializable]
    public class Person
    {
        public string name;
        public int age;

        public Person()
        {
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return this.name + ", " + this.age + " years old";
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            string n;
            int a;
            n = Console.ReadLine();
            a = Convert.ToInt16(Console.ReadLine());
            Person fe = new Person(n, a);
            mySerialize(fe);
            Console.Write(fe);
            myDeserialize();
            Console.ReadKey();
        }

        static void mySerialize(Person person)
        {
            BinaryFormatter xs = new BinaryFormatter();
            FileStream fs = new FileStream(
                "test.dat", FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                xs.Serialize(fs, person);
            }
            catch (Exception e)
            {
                Console.Write("General error: " + e);
            }
            fs.Close();
        }
        static void myDeserialize()
        {
            BinaryFormatter fr = new BinaryFormatter();
            FileStream fs = new FileStream(
                "test.dat", FileMode.Open, FileAccess.Read);
            try
            {
                Person person = fr.Deserialize(fs) as Person;
                Console.WriteLine(person);
            }
            catch (Exception e)
            {
                Console.WriteLine("Deserialize error: " + e);
            }

            fs.Close();
        }
    }
}
