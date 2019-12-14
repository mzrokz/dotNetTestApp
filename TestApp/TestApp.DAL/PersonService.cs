using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
