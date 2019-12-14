using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.DAL;
using TestApp.Mapper.Mapping;
using TestApp.Models;

namespace BAL
{
    public class PersonManager
    {

        public List<Person> GetPersons()
        {
            var personService = new PersonService();
            var ds = personService.GetPersons();

            DataNamesMapper<Person> mapper = new DataNamesMapper<Person>();
            List<Person> persons = mapper.Map(ds.Tables[0]).ToList();
            return persons;
        }
    }
}
