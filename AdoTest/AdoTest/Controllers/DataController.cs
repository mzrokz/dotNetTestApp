using AdoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdoTest.Controllers
{
    public class DataController : ApiController
    {
        [Route("api/data/getData")]
        [HttpGet()]
        public List<Player> getData()
        {
            Db db = new Db();

            return db.getData();
        }

        [Route("api/data/getAutoMapData")]
        [HttpGet()]
        public List<PlayerDto> getAutoMapData()
        {
            Db db = new Db();

            return db.getAutoMapData();
        }

        [Route("api/data/createPlayer")]
        [HttpPost()]
        public string createPlayer([FromBody] Player data)
        {
            Db db = new Db();
            db.CreatePlayer(data.speed, data.color,10000);
            return "Player Created Successfully.";
        }
    }
}
