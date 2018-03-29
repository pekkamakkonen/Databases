using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Task1.Model;

namespace Task1.Repositories
{
    class PersonRepository:IPersonRepository
    {
        private readonly LocaldbContext _context = new LocaldbContext();

        public void Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public List<Person> Get()
        {
            List<Person> persons = _context.Person.ToListAsync().Result;
            return persons;
        }

        public Person GetPersonById(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.PersonId == id);
            return person;
        }

        public void Update(int id, Person person)
        {
            var updatePerson = GetPersonById(id);
            if (updatePerson != null)
            {
                updatePerson.Name = person.Name;
                updatePerson.Age = person.Age;
                _context.Person.Update(person);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delPerson = _context.Person.FirstOrDefault(p => p.PersonId == id);
            if(delPerson != null)
            {
                _context.Person.Remove(delPerson);
            }
            _context.SaveChanges();
        }
    }
}
