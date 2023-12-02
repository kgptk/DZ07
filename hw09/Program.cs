using System.Text.Json;
using System.Xml.Serialization;
namespace hw09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Anna", 75);

            string jsonPerson = JsonSerializer.Serialize(person);
            Console.WriteLine(jsonPerson);
             
            // json строку десериализуем в объект класса Person
            Person? restoredPerson = JsonSerializer.Deserialize<Person>(jsonPerson);
            Console.WriteLine(restoredPerson?.Name);


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            // сериализуем объект класса Person в xml
            using (FileStream fs = new FileStream("p.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, person);

                Console.WriteLine("Object has been serialized");
            }
            
            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; } = "Undefined";
        public int Age { get; set; } = 1;

        public Person() { }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Name = {Name}, Age = {Age}";
        }

    }
}

