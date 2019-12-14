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

        //public List<Person> GetPersonsVizReader()
        //{

        //    List<Player> players = new List<Player>();
        //    using (var conn = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("SELECT TOP (20000) [Id],[speed],[color] FROM [test].[dbo].Players", conn);

        //        conn.Open();

        //        SqlDataReader rdr = command.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            Console.WriteLine(rdr["id"] + " " + rdr["speed"] + " " + rdr["color"]);
        //            players.Add(new Player((int)rdr["id"], (int)rdr["speed"], (string)rdr["color"]));
        //        }
        //        rdr.Dispose();
        //        command.Dispose();
        //    }
        //    return players;
        //}
    }
}
