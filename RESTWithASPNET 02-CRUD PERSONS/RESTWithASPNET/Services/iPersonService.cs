using RESTWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTWithASPNET.Services
{
    public interface IPersonService
    {
        Person create(Person person);
        Person findById(long id);
        List<Person> findAll();
        Person update(Person person);
        void delete(long id);




    }
}
