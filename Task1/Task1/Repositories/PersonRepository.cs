﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Task1.Model;

namespace Task1.Repositories
{
    class PersonRepository
    {
        private static LocaldbContext _context = new LocaldbContext();

        public static void Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public static List<Person> Get()
        {
            List<Person> persons = _context.Person.ToListAsync().Result;
            return persons;
        }

        public static Person GetPersonById(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.PersonId == id);
            return person;
        }

        public static void Update(int id, Person person)
        {
            var updatePerson = GetPersonById(id);
            if (updatePerson != null)
            {
                _context.Person.Update(person);
            }
            _context.SaveChanges();
        }

        public static void Delete(int id)
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
