using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using AdoTest.Infrastructure;

namespace AdoTest.Models
{

    public class Player
    {
        public int Id { get; set; }
        public int speed { get; set; }
        public string color { get; set; }

        public Player(int id, int sp, string cl)
        {
            Id = id;
            speed = sp;
            color = cl;
        }
    }
    public class PlayerDto
    {
        public int Id { get; set; }
        public int speed { get; set; }
        public string color { get; set; }
    }

    public class Db
    {
        private string ConnectionString = "Data Source=DESKTOP-OVURDFV;Initial Catalog=test;Persist Security Info=True;User ID=sa;Password=maramune12";

        public List<Player> getData()
        {
            List<Player> players = new List<Player>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT TOP (20000) [Id],[speed],[color] FROM [test].[dbo].Players", conn);

                conn.Open();

                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr["id"] + " " + rdr["speed"] + " " + rdr["color"]);
                    players.Add(new Player((int)rdr["id"], (int)rdr["speed"], (string)rdr["color"]));
                }
                rdr.Dispose();
                command.Dispose();
            }
            return players;
        }

        public List<PlayerDto> getAutoMapData()
        {
            List<PlayerDto> players = new List<PlayerDto>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT TOP (20000) [Id],[speed],[color] FROM [test].[dbo].Players", conn);

                conn.Open();

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    PlayerDto player = AutoMapperProfile.Mp.Map<PlayerDto>(rdr);
                    players.Add(player);
                }

                rdr.Dispose();
                command.Dispose();
            }

            return players;
        }

        public void CreatePlayer(int speed, string color, int loopNumber)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    con.Open();

                    for (int i = 0; i < loopNumber; i++)
                    {
                        command.CommandText = $"INSERT INTO Players (speed,color)values({speed},'{color}')";
                        command.Connection = con;
                        command.ExecuteNonQuery();
                    }

                }
            }
        }
    }
}