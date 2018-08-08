using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RESTWithASPNET.Model;
using RESTWithASPNET.Model.Context;

namespace RESTWithASPNET.Services.Implementations
{
    public class PersonServiceImpl : IPersonService {


        private MySqlContext _context;

        public PersonServiceImpl(MySqlContext context) {
            _context = context;
        }

        public Person create(Person person)
        {
            try {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw ex;
            }
            return person;
        }

        public void delete(long id)
        {
            var result = _context.persons.SingleOrDefault(p => p.id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> findAll()
        {
            return _context.persons.ToList();
        }


        public Person findById(long id)
        {
            return _context.persons.SingleOrDefault(p => p.id.Equals(id));
        }


        public Person update(Person person)
        {
            if (!Exist(person.id)) return new Person();

            var result = _context.persons.SingleOrDefault(p => p.id.Equals(person.id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        private bool Exist(long? id)
        {
            return _context.persons.Any(p => p.id.Equals(id));
        }
    }
}
