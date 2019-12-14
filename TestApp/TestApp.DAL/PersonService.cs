using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.DAL
{
    public class PersonService
    {

        public DataSet GetPersons()
        {
            var sql = "Select * from Person.Person";
            var context = new TestContext();
            var ds = context.ExecuteQuery(sql);
            return ds;
        }

        public List<Person> GetPersonsVizReader()
        {
            List<Person> lstPersons = new List<Person>();

            var sql = "Select * from Person.Person";

            var context = new TestContext();
            var dr = context.ExecuteReader(sql);
            while (dr.Read())
            {
                var oPerson = new Person();
                oPerson.BusinessEntityID = (int)dr["BusinessEntityID"];
                lstPersons.Add(oPerson);
            }
            dr.Dispose();
            return lstPersons;
        }
    }
}
