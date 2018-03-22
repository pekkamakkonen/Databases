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
            // Person person1 = new Person("Arto", 25);
            // PersonRepository.Create(person1);

            var persons = PersonRepository.Get();

            foreach (var p in persons)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("Press <Enter> to Exit");
            Console.ReadLine();
        }
    }
}
