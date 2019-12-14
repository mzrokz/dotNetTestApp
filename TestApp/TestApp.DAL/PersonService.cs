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

        public List<Player> GetPersonsVizReader()
        {
            List<Player> players = new List<Player>();

            string command = "SELECT TOP (20000) [Id],[speed],[color] FROM [test].[dbo].Players";

            var context = new TestContext();
            var dr = context.ExecuteReader(command);
            while (dr.Read())
            {
                players.Add(new Player((int)dr["id"], (int)dr["speed"], (string)dr["color"]));
            }
            dr.Dispose();
            return players;
        }
    }
}
