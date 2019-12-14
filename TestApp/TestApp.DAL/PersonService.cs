using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirst = TestApp.DAL.DBFirst;
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
                oPerson.BusinessEntityID = dr["BusinessEntityID"] != DBNull.Value ? (int)dr["BusinessEntityID"] : 0;
                oPerson.PersonType = dr["PersonType"] != DBNull.Value ? dr["PersonType"].ToString() : "";
                oPerson.NameStyle = dr["NameStyle"] != DBNull.Value ? Convert.ToBoolean(dr["NameStyle"]) : false;
                oPerson.Title = dr["Title"] != DBNull.Value ? dr["Title"].ToString() : "";
                oPerson.FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                oPerson.MiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                oPerson.LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                oPerson.Suffix = dr["Suffix"] != DBNull.Value ? dr["Suffix"].ToString() : "";
                oPerson.EmailPromotion = dr["EmailPromotion"] != DBNull.Value ? (int)dr["EmailPromotion"] : 0;
                oPerson.ModifiedDate = dr["ModifiedDate"] != DBNull.Value ? Convert.ToDateTime(dr["ModifiedDate"]) : new DateTime();
                lstPersons.Add(oPerson);
            }
            dr.Dispose();
            return lstPersons;
        }

        public List<Person> GetPersonsVizReaderMapper()
        {
            List<Person> lstPersons = new List<Person>();

            var sql = "Select * from Person.Person";

            var context = new TestContext();
            var dr = context.ExecuteReader(sql);
            while (dr.Read())
            {
                var oPerson = AutoMapper.Mapper.Map<Person>(dr);
                lstPersons.Add(oPerson);
            }
            dr.Dispose();
            return lstPersons;
        }

        public List<DbFirst.Person> GetPersonFromEFDBFirst()
        {
            var lstPersons = new List<DbFirst.Person>();
            using (var context = new DbFirst.AdventureWorks2014Entities())
            {
                lstPersons = context.People.ToList();
            }
            return lstPersons;
        }
    }
}
