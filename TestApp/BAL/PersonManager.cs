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

            // 2390 ms
            var ds = personService.GetPersons();
            DataNamesMapper<Person> mapper = new DataNamesMapper<Person>();
            List<Person> persons = mapper.Map(ds.Tables[0]).ToList();

            // 144 ms
            var oPersonsVizReader = personService.GetPersonsVizReader();
            // 133 ms
            var oPersonsVizReaderMapper = personService.GetPersonsVizReaderMapper();
            // 1st hit-1930ms | n>=2 hits-785 ms
            var oPersonsVizEfDbFirst = personService.GetPersonFromEFDBFirst();


            return persons;
        }
    }
}
