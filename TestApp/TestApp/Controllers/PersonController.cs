using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL;

namespace TestApp.Controllers
{
    public class PersonController : ApiController
    {

        public IHttpActionResult GetPersons()
        {
            var personManager = new PersonManager();
            var persons = personManager.GetPersons();
            return Ok(persons);
        }
    }
}
