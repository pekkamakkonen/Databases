using System;
using Task1.Model;
using Task1.Repositories;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");

            PersonRepository personRepository = new PersonRepository();

            Person newPerson = new Person("Roope Ankka", 80);
            personRepository.Create(newPerson);
            

            var persons = personRepository.Get();

            foreach (var p in persons)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("Press <Enter> to Exit");
            Console.ReadLine();
        }
    }
}
